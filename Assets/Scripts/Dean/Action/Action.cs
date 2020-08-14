using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public abstract class Action : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData == null) return;

        transform.SetParent(PlayManager.Instance.DropParent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData == null) return;

        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public virtual void Execute()
    { 
        
    }
}

public enum ActionOption
{ 
    Move,
    Turn
}

public enum MoveActionEvent
{
    Forward = 0,
    Backward = 1
}

public enum RotateActionEvent
{
    Right = 0,
    Left = 1
}
