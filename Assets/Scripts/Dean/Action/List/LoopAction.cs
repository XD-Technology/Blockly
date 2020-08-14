using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastPlayer
{

    public class LoopAction : Action
    {
        public List<Action> Actions = new List<Action>();

        private int count;

        private void Start()
        {
            count = 1;
        }

        public override void Execute()
        {
            base.Execute();

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < Actions.Count; j++)
                {
                    Actions[j].Execute();
                }
            }
        }

        public void OnValueChange_CountEvent(string value)
        {
            int.TryParse(value, out count);
        }
    }
}