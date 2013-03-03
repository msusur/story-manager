using StoryNode.Activities.Results;

namespace StoryNode.Models
{
    public abstract class ActivityBase
    {
        public string ActivityName { get; set; }

        public abstract ActivityResult ExecuteActivity(IStoryContext context);
    }
}