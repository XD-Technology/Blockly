using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public float MoveDistance = 200;
    public Transform Player;
    public LevelController LevelController;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        Player.position = LevelController.Points[0].position;
    }

    internal void Move(MoveActionEvent moveActionEvent)
    {
        if (moveActionEvent == MoveActionEvent.Forward)
        {
            Player.Translate(Vector3.up * MoveDistance);
        }
        else
        {
            Player.Translate(Vector3.down * MoveDistance);
        }
    }

    internal void Rotate(RotateActionEvent rotateActionEvent)
    {
        if (rotateActionEvent == RotateActionEvent.Right)
        {
            Player.Rotate(-Vector3.forward * 90);
        }
        else
        {
            Player.Rotate(Vector3.forward * 90);
        }
    }
}
