using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LastPlayer.Blockly
{
    public class FunctionBlock : BaseBlock, IDragHandler, IEndDragHandler, IBeginDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private Image image;

        public GameObject aligned;
        public Transform child;
        public Transform parent;

        private bool hasChild => child.childCount > 0;

        public void OnBeginDrag(PointerEventData eventData)
        {
            NewParent = null;
            if (image == null) image = GetComponent<Image>();
            BlockToHandle = gameObject;
            DeleteBlock.Show();
            image.raycastTarget = false;
            parent.SetParent(drapParent);
        }

        public void OnDrag(PointerEventData eventData)
        {
            parent.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (image == null) image = GetComponent<Image>();
            DeleteBlock.Hide();
            image.raycastTarget = true;
            if (NewParent == null) parent.SetParent(designParent);
            else parent.SetParent(NewParent);
            BlockToHandle = null;
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (hasChild) return;
            var blockData = eventData.pointerDrag.gameObject.GetComponent<IBlockData>();
            if (blockData != null && blockData.BlockToHandle != null) blockData.NewParent = child;
            aligned.SetActive(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (hasChild) return;
            aligned.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (hasChild) return;
            aligned.SetActive(false);
        }
    }
}