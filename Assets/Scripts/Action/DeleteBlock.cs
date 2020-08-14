using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LastPlayer.DeanBlockly
{
    public class DeleteBlock : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            //Debug.Log("OnDrop");
            //if (eventData == null) return;
            //Destroy(eventData.pointerDrag);

            var blockData = eventData.pointerDrag.GetComponent<IBlockData>();
            if (!blockData.CancelEvent)
            {
                Debug.Log("Deleted " + blockData.BlockToHandle.name);
                Destroy(blockData.BlockToHandle);
            }
        }
    }
}