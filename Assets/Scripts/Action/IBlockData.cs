using UnityEngine;

namespace LastPlayer.DeanBlockly
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