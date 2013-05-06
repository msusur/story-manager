using System;
using StoryBoard.Entities;

namespace StoryBoard.Exceptions
{
    [Serializable]
    public class NodeInvokerNotFoundException : Exception
    {
        public NodeInvokerNotFoundException(NodeBase node)
            :base(string.Format("Invoker '{0}' named node for type '{1}' not found.", node.NodeName, node.GetType().FullName))
        {
            
        }
    }
}
