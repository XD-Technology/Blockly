using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

namespace LastPlayer
{

    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance;

        public float MoveDistance = 200;
        public LevelController LevelController;
        public UILineRenderer UILineRenderer;

        private int levelPointIndex;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            levelPointIndex = 0;
            transform.position = LevelController.Points[0].position;
            transform.rotation = Quaternion.identity;
            ClearPointList();
            AddNewPoint(LevelController.Points[0].localPosition.x, LevelController.Points[0].localPosition.y);
        }

        internal void Move(MoveActionEvent moveActionEvent)
        {
            //Vector3 currentPos = transform.position;
            //if (moveActionEvent == MoveActionEvent.Forward)
            //{
            //    transform.Translate(Vector3.up * MoveDistance);
            //    //iTween.MoveFrom(gameObject, currentPos, 1f);
            //}
            //else
            //{
            //    transform.Translate(Vector3.down * MoveDistance);
            //    //iTween.MoveTo(gameObject, currentPos, 1f);
            //}

            levelPointIndex++;
            if (levelPointIndex >= LevelController.Points.Length)
            {
                levelPointIndex = 0;
            }

            iTween.MoveTo(gameObject, LevelController.Points[levelPointIndex].position, 1f);

            AddNewPoint(LevelController.Points[levelPointIndex].localPosition.x, LevelController.Points[levelPointIndex].localPosition.y);
        }

        public void AddNewPoint(float x, float y)
        {
            var point = new Vector2() 
            { 
                x = x, 
                y = y
            };
            var pointlist = new List<Vector2>(UILineRenderer.Points);
            pointlist.Add(point);
            UILineRenderer.Points = pointlist.ToArray();
        }

        public void ClearPointList()
        {
            var pointlist = new List<Vector2>(UILineRenderer.Points);
            pointlist.Clear();
            UILineRenderer.Points = pointlist.ToArray();
        }

        internal void Rotate(RotateActionEvent rotateActionEvent)
        {
            if (rotateActionEvent == RotateActionEvent.Right)
            {
                iTween.RotateAdd(gameObject, -Vector3.forward * 90, 1);
            }
            else
            {
                iTween.RotateAdd(gameObject, Vector3.forward * 90, 1);
            }
        }
    }
}