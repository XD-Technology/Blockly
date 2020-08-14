using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

namespace LastPlayer.Blockly
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance;
        public RectTransform transformR;
        public float MoveDistance = 200;
        public LevelController LevelController;
        public UILineRenderer lineR;

        private Vector2 startPos;

        private void Awake()
        {
            Instance = this;
            transformR = GetComponent<RectTransform>();
            
        }

        private void Start()
        {
            startPos = transformR.anchoredPosition;
            Init();
        }

        public void Init()
        {
            transformR.anchoredPosition = startPos;
            transform.rotation = Quaternion.identity;
            ClearPointList();
            AddNewPoint(transformR.localPosition.x, transformR.localPosition.y);
            //AddNewPoint(transformR.offsetMin.x, transformR.offsetMin.y);
        }

        internal void Move(MoveActionEvent moveActionEvent)
        {
            if (moveActionEvent == MoveActionEvent.Forward) transformR.Translate(Vector3.up * MoveDistance);
            else transformR.Translate(Vector3.down * MoveDistance);

            //if (moveActionEvent == MoveActionEvent.Forward) transformR.anchoredPosition = new Vector2(transformR.anchoredPosition.x, transformR.offsetMax.y + 800);
            //else transformR.offsetMax = new Vector2(transformR.offsetMax.x, transformR.offsetMax.y - 800);

            //float x = transformR.offsetMin.x;
            //float y = transformR.offsetMin.y;
            //AddNewPoint((float)x, (float)y);
            AddNewPoint(transformR.localPosition.x, transformR.localPosition.y);
        }

        internal void Rotate(RotateActionEvent rotateActionEvent)
        {
            if (rotateActionEvent == RotateActionEvent.Right)
            {
                transform.Rotate(-Vector3.forward * 90);
            }
            else
            {
                transform.Rotate(Vector3.forward * 90);
            }
        }

        public void AddNewPoint(float x, float y)
        {
            var point = new Vector2()
            {
                x = x,
                y = y
            };
            var pointlist = new List<Vector2>(lineR.Points);
            pointlist.Add(point);
            lineR.Points = pointlist.ToArray();
        }

        public void ClearPointList()
        {
            var pointlist = new List<Vector2>(lineR.Points);
            pointlist.Clear();
            lineR.Points = pointlist.ToArray();
        }

        [ContextMenu("Display")]
        public void DisplayeV()
        {
            transformR = GetComponent<RectTransform>();
            Debug.Log(transformR.offsetMin);
            Debug.Log(transformR.offsetMax);
            Debug.Log(transformR.anchorMax);
            Debug.Log(transformR.anchorMin);
        }
    }
}