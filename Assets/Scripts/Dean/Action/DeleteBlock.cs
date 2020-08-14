using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteBlock : MonoBehaviour, IDropHandler, IPointerEnterHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData == null) return;

        Destroy(eventData.pointerDrag);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        //Debug.Log(eventData.pointerDrag.name);
    }
}
