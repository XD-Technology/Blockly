using LastPlayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastPlayer
{
    public class PlayManager : MonoBehaviour
    {
        public static PlayManager Instance;

        public Transform DropParent;

        private void Awake()
        {
            Instance = this;
        }
    }
}