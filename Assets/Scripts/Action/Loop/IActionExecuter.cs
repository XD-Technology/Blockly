using UnityEngine;

namespace LastPlayer.DeanBlockly
{
    public interface IActionExecuter
    {
        void RemoveAction(Action action);
        void AddAction(Action action);

        ParentTypeBlock Type { get; }
    }

    public enum ParentTypeBlock
    {
        Executer,
        Design,
        Other
    }
}