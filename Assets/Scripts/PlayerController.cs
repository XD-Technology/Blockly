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
        private int index;

        private void Awake()
        {
            Instance = this;
            
        }

        private void Start()
        {
            //startPos = transformR.anchoredPosition;
            Init();
        }

        public void Init()
        {
            index = 0;
            transformR.position = LevelController.grid[0].position;
            transform.rotation = Quaternion.identity;
            ClearPointList();
            AddNewPoint(transformR.localPosition.x, transformR.localPosition.y);
        }

        internal void Move(MoveActionEvent moveActionEvent)
        {
            if (moveActionEvent == MoveActionEvent.Forward)
            {
                //transform.Translate(Vector3.up * MoveDistance, Space.World);
                index++;
                if (index >= LevelController.grid.Count) index = 0;

                transformR.position = LevelController.grid[index].position;
            }
            else transform.Translate(Vector3.down * MoveDistance);

            AddNewPoint(transformR.localPosition.x, transformR.localPosition.y);
            LevelController.AddVisitedPoint(LevelController.grid[index]);
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