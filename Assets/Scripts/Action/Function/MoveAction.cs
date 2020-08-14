using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LastPlayer.DeanBlockly
{
    public sealed class MoveAction : Action, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public MoveActionEvent MoveActionEvent;

        private Vector2 offset = Vector3.zero;

        public override void Execute()
        {
            base.Execute();
            PlayerController.Instance.Move(MoveActionEvent);
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
                if (parent != null)
                {
                    parent.RemoveAction(this);
                    NewParent = null;
                }
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
            else BlockToHandle.transform.SetParent(NewParent);
        }

        public void OnValueChange_ActionEvent(int value)
        {
            MoveActionEvent = (MoveActionEvent)value;
        }
    }

    public enum MoveActionEvent
    {
        Forward = 0,
        Backward = 1
    }
}