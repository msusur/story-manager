using StoryBoard.Entities;
using StoryBoard.Entities.Conditions;
using StoryBoard.Exceptions;

namespace StoryBoard.Invokers
{
    internal static class NodeInvokerFactory
    {
        public static NodeInvokerBase GetInvoker(NodeBase node)
        {
            if (node is StoryNode)
            {
                return new StoryNodeInvoker();
            }
            if (node is StoryNodeGroup)
            {
                return new StoryNodeGroupInvoker();
            }
            throw new NodeInvokerNotFoundException(node);
        }
    }
}
