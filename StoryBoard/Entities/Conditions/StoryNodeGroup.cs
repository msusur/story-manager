using System;
using System.Collections.Generic;

namespace StoryBoard.Entities.Conditions
{
    [Serializable]
    public class StoryNodeGroup : NodeBase
    {
        public IList<ConditionBase> Conditions { get; private set; }

        public IList<StoryNode> StoryNodes { get; set; }

        public StoryNodeGroup(string nodeName, ConditionBase routeCondition)
            : base(nodeName)
        {
            Conditions = new List<ConditionBase> { routeCondition };
        }

        public StoryNodeGroup AddCondition(ConditionBase routeCondition)
        {
            Conditions.Add(routeCondition);
            return this;
        }

        public StoryNodeGroup AddNode(StoryNode storyNode)
        {
            StoryNodes.Add(storyNode);
            return this;
        }
    }
}