using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LastPlayer.Blockly
{
    public abstract class BaseBlock : MonoBehaviour, IBlockData
    {
        protected static Transform drapParent;
        protected static Transform designParent;

        public bool CancelEvent { get; protected set; }
        public virtual GameObject BlockToHandle { get; protected set; }
        public virtual Transform NewParent { get; set; }
        public BlockType BlockType;

        protected void Awake()
        {
            BlockToHandle = null;
            if (drapParent == null) drapParent = GameObject.Find("DragDropParent").transform;
            if (designParent == null) designParent = GameObject.Find("Design").transform;
        }

        public bool Execute()
        {
            return true;
        }

        public string GenerateCode()
        {
            return string.Empty;
        }
    }

    public interface IBlockData
    {
        GameObject BlockToHandle { get; }
        bool CancelEvent { get; }
        Transform NewParent { get; set; }

        bool Execute();
        string GenerateCode();
    }

    public enum BlockType
    { 
        MoveForward,
        TurnRight,
        TurnLeft,
        Loop
    }
}
