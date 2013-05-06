using System;

namespace StoryBoard.Entities
{
    [Serializable]
    public abstract class NodeBase
    {
        public string NodeName { get; set; }

        [Obsolete("Dynamic serialization only.")]
        protected NodeBase()
        {

        }

        protected NodeBase(string nodeName)
        {
            NodeName = nodeName;
        }
    }
}