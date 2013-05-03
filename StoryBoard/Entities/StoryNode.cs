using System;
using System.Collections.Generic;

namespace StoryBoard2.Entities
{
    [Serializable]
    public class StoryNode
    {
        public IList<Activity> Activities { get; private set; }

        public string NodeName { get; set; }

        [Obsolete("Dynamic serialization only.")]
        public StoryNode()
        {
            
        }

        public StoryNode(string nodeName, params Activity[] activities)
        {
            if (string.IsNullOrEmpty(nodeName))
            {
                throw new ArgumentNullException("nodeName");
            }

            if (activities == null || activities.Length < 1)
            {
                throw new ArgumentException("Activities must have at least one member.", "activities");
            }

            NodeName = nodeName;
            Activities = new List<Activity>(activities);
        }
    }
}