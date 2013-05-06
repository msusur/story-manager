using System;
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
                                 ? null
                                 : context.CurrentDefinition.GetNodeByName<NodeBase>(lastNodeName);
            var index = node == null ? -1 : context.CurrentDefinition.StoryNodes.IndexOf(node);
            node = context.CurrentDefinition.StoryNodes[index + 1];
            var result = ExecuteNode(context, node);
            // ReSharper disable PossibleNullReferenceException
            var lastItemNodeName = context.CurrentDefinition.StoryNodes.LastOrDefault().NodeName;
            // ReSharper restore PossibleNullReferenceException
            result.IsEnded = lastItemNodeName.Equals(node.NodeName, StringComparison.CurrentCultureIgnoreCase);
            result.CurrentStepName = node.NodeName;
            return result;
        }

        private static StoryResult ExecuteNode(StoryContext context, NodeBase node)
        {
            NodeInvokerBase invokerBase = NodeInvokerFactory.GetInvoker(node);

            return invokerBase.InvokeNode(context, node);
        }
    }
}