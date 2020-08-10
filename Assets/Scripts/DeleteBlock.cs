using UnityEngine;
using UnityEngine.EventSystems;

namespace LastPlayer.Blockly
{
    public class DeleteBlock : MonoBehaviour, IDropHandler
    {
        private static DeleteBlock instance;

        private void Awake()
        {
            instance = this;
            gameObject.SetActive(false);
        }

        public void OnDrop(PointerEventData eventData)
        {
            var blockData = eventData.pointerDrag.GetComponent<IBlockData>();
            if (!blockData.CancelEvent)
            {
                Debug.Log("Deleted " + blockData.BlockToHandle.name);
                Destroy(blockData.BlockToHandle);
                Hide();
            }
        }

        public static void Show()
        {
            instance.gameObject.SetActive(true);
        }

        public static void Hide()
        {
            instance.gameObject.SetActive(false);
        }
    }
}