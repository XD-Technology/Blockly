using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LastPlayer.Blockly
{
    public abstract class Action : MonoBehaviour, IBlockData
    {
        protected static Transform dragParent;
        protected static Transform designParent;

        public bool CancelEvent { get; protected set; }
        public virtual GameObject BlockToHandle { get; protected set; }
        public virtual Transform NewParent { get; set; }

        protected virtual void Awake()
        {
            BlockToHandle = null;
            if (dragParent == null) dragParent = GameObject.Find("DropParent").transform;
            if (designParent == null) designParent = GameObject.Find("DesignParent").transform;
        }

        public virtual void Execute() { }

        public string GenerateCode()
        {
            return string.Empty;
        }
    }

    public enum ActionOption
    {
        Move,
        Turn
    }
}