using UnityEngine;
using UnityEngine.EventSystems;

namespace LastPlayer.DeanBlockly
{
    public class DesignBlock : MonoBehaviour, IDropHandler, IActionExecuter
    {
        [SerializeField] private ParentTypeBlock type;
        public ParentTypeBlock Type => ParentTypeBlock.Design;

        public void OnDrop(PointerEventData eventData)
        {
            var blockData = eventData.pointerDrag.GetComponent<IBlockData>();
            if (blockData != null && !blockData.CancelEvent && blockData.BlockToHandle != null) blockData.NewParent = transform;
        }

        public void RemoveAction(Action action) { }
        public void AddAction(Action action) { }
    }
}