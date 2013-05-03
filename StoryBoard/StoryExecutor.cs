using System.Linq;
using StoryBoard.Abstractions;
using StoryBoard.Entities;

namespace StoryBoard
{
    public class StoryExecutor : IStoryExecutor
    {
        public StoryResult Next(StoryContext context, string lastNodeName)
        {
            var node = string.IsNullOrEmpty(lastNodeName)
                                 ? context.CurrentDefinition.StoryNodes.FirstOrDefault()
                                 : context.CurrentDefinition.GetNodeByName(lastNodeName);
            var index = context.CurrentDefinition.StoryNodes.IndexOf(node);
            node = context.CurrentDefinition.StoryNodes[index + 1];
            return ExecuteNode(context, node);
        }

        private static StoryResult ExecuteNode(StoryContext context, StoryNode node)
        {
            var activityContext = new ActivityContext(context);
            foreach (var activity in node.Activities)
            {
                activity.Execute(activityContext);
            }
            return new StoryResult(activityContext) ;//TODO: convert activity context to story result. 
        }
    }
}