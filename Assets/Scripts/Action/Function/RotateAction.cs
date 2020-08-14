using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LastPlayer.Blockly
{
    public class RotateAction : Action, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public RotateActionEvent RotateActionEvent;
        private Vector2 offset;

        public override void Execute()
        {
            base.Execute();
            PlayerController.Instance.Rotate(RotateActionEvent);
        }

        public void OnValueChange_ActionEvent(int value)
        {
            RotateActionEvent = (RotateActionEvent)value;
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
            else BlockToHandle.transform.SetParent(NewParent);
        }
    }

    public enum RotateActionEvent
    {
        Right = 0,
        Left = 1
    }
}