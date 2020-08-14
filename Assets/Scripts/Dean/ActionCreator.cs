using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCreator : MonoBehaviour
{
    public Transform ParentHolder;

    public GameObject[] TurtleObjects;
    public GameObject[] LoopObjects;

    public void InitTurtle()
    {
        Remove();
        for (int i = 0; i < TurtleObjects.Length; i++)
        {
            Instantiate(TurtleObjects[i], ParentHolder);
        }
    }

    public void InitLoop()
    {
        Remove();
        for (int i = 0; i < LoopObjects.Length; i++)
        {
            Instantiate(LoopObjects[i], ParentHolder);
        }
    }

    private void Remove()
    {
        foreach (Transform item in ParentHolder)
        {
            Destroy(item.gameObject);
        }
    }
}
