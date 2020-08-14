using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LastPlayer.DeanBlockly
{
    public class LoopAction : Action, IDropHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IActionExecuter
    {
        [SerializeField] private List<Action> actions = new List<Action>();
        [SerializeField] private Transform holder = null;

        private Vector2 offset;
        private int count;
        private ContentSizeFitter fitter;

        [SerializeField] private ParentTypeBlock type;
        public ParentTypeBlock Type => ParentTypeBlock.Other;

        private void Start()
        {
            count = 1;
            fitter = GetComponent<ContentSizeFitter>();
        }

        public override void Execute()
        {
            base.Execute();

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < actions.Count; j++)
                {
                    actions[j].Execute();
                }
            }
        }

        public void OnValueChange_CountEvent(string value)
        {
            int.TryParse(value, out count);
        }

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("Loop Drop");
            if (holder != null)
            {
                IBlockData data = eventData.pointerDrag.GetComponentInChildren<IBlockData>();
                var actionData = data.BlockToHandle.GetComponentInChildren<Action>(true);
                if (data != null && !data.CancelEvent && data.BlockToHandle != null)
                {
                    data.NewParent = holder;
                    AddAction(actionData);
                }
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            BlockToHandle = gameObject;
            GetComponentInChildren<Graphic>(true).raycastTarget = false;
            offset = new Vector2(transform.position.x, transform.position.y) - eventData.position;
            BlockToHandle.transform.SetParent(dragParent);
            if (NewParent != null)
            {
                var parent = NewParent.GetComponentInParent<IActionExecuter>();
                parent.RemoveAction(this);
                NewParent = null;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            BlockToHandle.transform.position = eventData.position + offset;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            GetComponentInChildren<Graphic>(true).raycastTarget = true;
            if (NewParent == null) BlockToHandle.transform.SetParent(designParent);
            else
            {
                BlockToHandle.transform.SetParent(NewParent);
                var type = NewParent.GetComponentInParent<IActionExecuter>();
                if (type != null)
                {
                    switch (type.Type)
                    {
                        case ParentTypeBlock.Executer:
                            fitter.enabled = false;
                            break;
                        case ParentTypeBlock.Design:
                            fitter.enabled = true;
                            break;
                        case ParentTypeBlock.Other:
                            break;
                    }
                }
            }
        }

        public void RemoveAction(Action action)
        {
            if (actions == null) actions = new List<Action>();
            if (action != null && actions.Contains(action))
            {
                actions.Remove(action);
            }
        }

        public void AddAction(Action action)
        {
            if (actions == null) actions = new List<Action>();
            if (action != null && !actions.Contains(action))
            {
                actions.Add(action);
            }
        }
    }


}
