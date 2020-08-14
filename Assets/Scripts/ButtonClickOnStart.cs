using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LastPlayer.Blockly
{
    public class ButtonClickOnStart : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            EventSystem e = GameObject.Find("EventSystem").GetComponent<EventSystem>();
            e.firstSelectedGameObject = gameObject;
            var b = GetComponent<Button>();
            b.onClick.Invoke();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}