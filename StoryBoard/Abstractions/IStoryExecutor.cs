using StoryBoard2.Entities;

namespace StoryBoard2.Abstractions
{
    public interface IStoryExecutor
    {
        StoryResult Next(StoryDefinition definition, string storyNode);
    }
}