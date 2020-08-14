using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LastPlayer
{
    public class Executor : MonoBehaviour, IDropHandler
    {
        public List<Action> actions = new List<Action>();

        public void Execute()
        {
            for (int i = 0; i < actions.Count; i++)
            {
                actions[i].Execute();
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("Drop");
        }
    }
}