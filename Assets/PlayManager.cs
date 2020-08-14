using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public static PlayManager Instance;

    public Transform DropParent;

    private void Awake()
    {
        Instance = this;
    }
}
