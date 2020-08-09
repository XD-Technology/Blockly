using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LastPlayer.Blockly
{
    public class BlockCreator : BaseBlock, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        [SerializeField] private GameObject block = null;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (block != null)
            {
                DeleteBlock.Show();
                if (BlockToHandle != null) Destroy(BlockToHandle);
                BlockToHandle = Instantiate(block, drapParent);
                BlockToHandle.transform.position = transform.position;
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
                BlockToHandle.GetComponent<Image>().raycastTarget = true;
                if (NewParent == null) BlockToHandle.transform.SetParent(designParent);
                else BlockToHandle.transform.SetParent(NewParent);
                NewParent = null;
                BlockToHandle = null;
            }

            DeleteBlock.Hide();
        }
    }
}