using System;

namespace StoryBoard.Entities.Conditions
{
    [Serializable]
    public abstract class ConditionBase
    {
        public string NodeName { get; set; }

        protected ConditionBase(string nodeName)
        {
            NodeName = nodeName;
        }

        public abstract bool CanExecute(StoryContext context);
    }
}