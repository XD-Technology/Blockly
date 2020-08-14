using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : Action
{
    public MoveActionEvent MoveActionEvent;

    public override void Execute()
    {
        base.Execute();

        PlayerController.Instance.Move(MoveActionEvent);
    }

    public void OnValueChange_ActionEvent(int value)
    {
        MoveActionEvent = (MoveActionEvent)value;
    }
}
