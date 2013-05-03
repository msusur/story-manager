using StoryBoard.Entities;

namespace StoryBoard.Abstractions
{
    public interface IStoryManager
    {
        StoryResult ExecuteStory(StoryContext context, string storyName);
        StoryResult ExecuteStory(StoryContext context, string storyName, string storyNode);
    }
}