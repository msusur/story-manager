using StoryBoard.Entities;

namespace StoryBoard.Abstractions
{
    public interface IStoryExecutor
    {
        StoryResult Next(StoryContext context, string lastNodeName);
    }
}