using UnityEngine;

namespace LastPlayer.Blockly
{
    public interface IBlockData
    {
        GameObject BlockToHandle { get; }
        bool CancelEvent { get; }
        Transform NewParent { get; set; }

        void Execute();
        string GenerateCode();
    }
}