using System;
using System.Linq;
using StoryBoard.Entities;
using StoryBoard.Entities.Conditions;
using StoryBoard.Exceptions;

namespace StoryBoard.Invokers
{
    internal class StoryNodeGroupInvoker : NodeInvokerBase
    {
        public override StoryResult InvokeNode(StoryContext context, NodeBase node)
        {
            var group = node as StoryNodeGroup;
            if (group == null)
            {
                throw new ArgumentException("node must be derived from StoryNodeGroup in order to invoked.", "node");
            }
            var nodeToRun = string.Empty;
            foreach (var condition in group.Conditions)
            {
                var allowed = condition.CanExecute(context);
                if (!allowed) continue;
                nodeToRun = condition.NodeName;
                break;
            }
            var selectedNode = @group.StoryNodes.FirstOrDefault(storyNode => storyNode.NodeName.Equals(nodeToRun, StringComparison.CurrentCultureIgnoreCase));
            if (selectedNode == null)
            {
                throw new ConditionPointsUnavailableNodeException(nodeToRun);
            }
            var invoker = new StoryNodeInvoker();
            return invoker.InvokeNode(context, selectedNode);
        }
    }
}