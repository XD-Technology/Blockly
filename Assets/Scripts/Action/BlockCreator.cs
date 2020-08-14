using LastPlayer.Blockly;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LastPlayer.Blockly
{
    public class BlockCreator : Action, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        [SerializeField] private GameObject block = null;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (block != null)
            {
                if (BlockToHandle != null) Destroy(BlockToHandle);
                BlockToHandle = Instantiate(block, dragParent);
                BlockToHandle.transform.position = transform.position;
                BlockToHandle.GetComponentInChildren<Image>().raycastTarget = false;
                var actionExecuter = BlockToHandle.GetComponentInChildren<IActionExecuter>(true);
                if (actionExecuter != null) actionExecuter.Fitter.enabled = true;
                CancelEvent = false;
            }
            else CancelEvent = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!CancelEvent && BlockToHandle != null)
            {
                BlockToHandle.transform.position = eventData.position;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!CancelEvent && BlockToHandle != null)
            {
                BlockToHandle.GetComponentInChildren<Image>().raycastTarget = true;
                if (NewParent == null) BlockToHandle.transform.SetParent(designParent);
                else
                {
                    var blockData = BlockToHandle.GetComponentInChildren<IBlockData>(true);
                    if (blockData != null) blockData.NewParent = NewParent;
                    BlockToHandle.transform.SetParent(NewParent);
                    
                }
                NewParent = null;
                BlockToHandle = null;
            }
        }
    }
}