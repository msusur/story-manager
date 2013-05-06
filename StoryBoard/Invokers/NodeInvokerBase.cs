using StoryBoard.Entities;

namespace StoryBoard.Invokers
{
    internal abstract class NodeInvokerBase
    {
        public abstract StoryResult InvokeNode(StoryContext context, NodeBase node);
    }
}