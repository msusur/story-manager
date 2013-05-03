using StoryBoard.Entities;

namespace StoryBoard
{
    public class ActivityContext : StoryContext
    {
        public string CurrentNodeName { get; set; }

        public ActivityContext(StoryContext context)
        {
            CurrentDefinition = context.CurrentDefinition;
            CurrentStoryName = context.CurrentStoryName;
        }
    }
}