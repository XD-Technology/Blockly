using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAction : Action
{
    public RotateActionEvent RotateActionEvent;

    public override void Execute()
    {
        base.Execute();

        PlayerController.Instance.Rotate(RotateActionEvent);
    }

    public void OnValueChange_ActionEvent(int value)
    {
        RotateActionEvent = (RotateActionEvent)value;
    }
}
