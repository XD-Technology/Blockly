using System;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LastPlayer.Blockly
{
    public class StartBlock : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public GameObject Aligned;
        public Transform ChildParent;

        private bool hasChild => ChildParent.childCount > 0;

        public void OnDrop(PointerEventData eventData)
        {
            if (hasChild) return;
            var blockData = eventData.pointerDrag.gameObject.GetComponent<IBlockData>();
            if (blockData != null && blockData.BlockToHandle != null) blockData.NewParent = ChildParent;
            Aligned.SetActive(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (hasChild) return;
            Aligned.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (hasChild) return;
            Aligned.SetActive(false);
        }
    }
}