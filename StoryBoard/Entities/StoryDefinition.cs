using System;
using System.Linq;
using System.Collections.Generic;

namespace StoryBoard.Entities
{
    [Serializable]
    public class StoryDefinition
    {
        public IList<NodeBase> StoryNodes { get; private set; }

        public string StoryName { get; set; }

        [Obsolete("Dynamic serialization only.")]
        public StoryDefinition()
        {

        }

        public StoryDefinition(string storyName, params NodeBase[] storyNodes)
        {
            if (string.IsNullOrEmpty(storyName))
            {
                throw new ArgumentNullException("storyName");
            }
            if (storyNodes == null || storyName.Length < 1)
            {
                throw new ArgumentException("Story must have at least one story node.", "storyNodes");
            }
            StoryNodes = new List<NodeBase>(storyNodes);
            StoryName = storyName;
        }

        internal TNodeType GetNodeByName<TNodeType>(string storyNodeName)
            where TNodeType : NodeBase
        {
            return (TNodeType)StoryNodes.First(n => n.NodeName.Equals(storyNodeName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}