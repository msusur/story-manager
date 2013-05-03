using StoryBoard2.Entities;

namespace StoryBoard2.Abstractions
{
    public interface IStoryManager
    {
        StoryResult ExecuteStory(StoryContext context, string storyName);
        StoryResult ExecuteStory(StoryContext context, string storyName, string storyNode);
    }
}