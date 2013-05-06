using System;
using StoryBoard.Entities;

namespace StoryBoard.Invokers
{
    internal class StoryNodeInvoker : NodeInvokerBase
    {
        public override StoryResult InvokeNode(StoryContext context, NodeBase node)
        {
            var storyNode = node as StoryNode;
            if (storyNode == null)
            {
                throw new ArgumentException("Node must be a StoryNode in order to invoke.", "node");
            }
            var activityContext = new ActivityContext(context);

            foreach (var activity in storyNode.Activities)
            {
                activity.Execute(activityContext);
            }
            return new StoryResult(activityContext);//TODO: convert activity context to story result. 
        }
    }
}
