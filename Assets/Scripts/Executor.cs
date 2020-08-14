using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LastPlayer.DeanBlockly
{
    public class Executor : MonoBehaviour, IDropHandler, IActionExecuter
    {
        [SerializeField] private List<Action> actions = new List<Action>();
        [SerializeField] private Transform holder = null;
        [SerializeField] private ParentTypeBlock type;
        public ParentTypeBlock Type => ParentTypeBlock.Executer;

        public void Execute()
        {
            for (int i = 0; i < actions.Count; i++)
            {
                actions[i].Execute();
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (holder != null)
            {
                IBlockData data = eventData.pointerDrag.GetComponentInChildren<IBlockData>();
                var actionData = data.BlockToHandle.GetComponentInChildren<Action>(true);
                if (data != null && !data.CancelEvent && data.BlockToHandle != null && actionData != null)
                {
                    data.NewParent = holder;
                    actions.Add(actionData);
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