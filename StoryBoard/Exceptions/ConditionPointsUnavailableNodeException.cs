using System;

namespace StoryBoard.Exceptions
{
    [Serializable]
    public class ConditionPointsUnavailableNodeException : Exception
    {
        public ConditionPointsUnavailableNodeException(string nodeToRun)
            : base(string.Format("Available condition that points to the node '{0}' not found.", nodeToRun))
        { }
    }
}