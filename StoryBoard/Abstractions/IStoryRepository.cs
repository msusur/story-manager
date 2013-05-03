using StoryBoard.Entities;

namespace StoryBoard.Abstractions
{
    public interface IStoryRepository
    {
        StoryDefinition GetStoryByName(string name);
    }
}