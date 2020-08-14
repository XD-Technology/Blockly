using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LastPlayer.Blockly
{
    public interface IActionExecuter
    {
        void RemoveAction(Action action);
        void AddAction(Action action);

        ContentSizeFitter Fitter { get; }
        ParentTypeBlock Type { get; }
    }

    public enum ParentTypeBlock
    {
        Executer,
        Design,
        Other
    }
}