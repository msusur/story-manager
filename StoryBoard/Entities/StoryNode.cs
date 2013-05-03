using System;
using System.Collections.Generic;
using StoryBoard.Entities.Activities;

namespace StoryBoard.Entities
{
    [Serializable]
    public class StoryNode
    {
        public IList<ActivityBase> Activities { get; private set; }

        public string NodeName { get; set; }

        [Obsolete("Dynamic serialization only.")]
        public StoryNode()
        {
            
        }

        public StoryNode(string nodeName, params ActivityBase[] activitiesBase)
        {
            if (string.IsNullOrEmpty(nodeName))
            {
                throw new ArgumentNullException("nodeName");
            }

            if (activitiesBase == null || activitiesBase.Length < 1)
            {
                throw new ArgumentException("Activities must have at least one member.", "activitiesBase");
            }

            NodeName = nodeName;
            Activities = new List<ActivityBase>(activitiesBase);
        }
    }
}