using UnityEngine;
using UnityEngine.EventSystems;

namespace LastPlayer.Blockly
{
    public class DesignBlock : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {

            var blockData = eventData.pointerDrag.GetComponent<IBlockData>();
            if (!blockData.CancelEvent && blockData.BlockToHandle != null) blockData.NewParent = transform;
        }
    }
}