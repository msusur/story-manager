using System.Linq;
using StoryBoard.Abstractions;
using StoryBoard.Entities;
using StoryBoard.Invokers;

namespace StoryBoard
{
    public class StoryExecutor : IStoryExecutor
    {
        public StoryResult Next(StoryContext context, string lastNodeName)
        {
            var node = string.IsNullOrEmpty(lastNodeName)
                                 ? context.CurrentDefinition.StoryNodes.FirstOrDefault()
                                 : context.CurrentDefinition.GetNodeByName<NodeBase>(lastNodeName);
            var index = context.CurrentDefinition.StoryNodes.IndexOf(node);
            node = context.CurrentDefinition.StoryNodes[index + 1];
            return ExecuteNode(context, node);
        }

        private static StoryResult ExecuteNode(StoryContext context, NodeBase node)
        {
            NodeInvokerBase invokerBase = NodeInvokerFactory.GetInvoker(node);

            return invokerBase.InvokeNode(context, node);
        }
    }
}