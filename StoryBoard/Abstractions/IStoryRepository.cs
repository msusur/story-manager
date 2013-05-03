using StoryBoard2.Entities;

namespace StoryBoard2.Abstractions
{
    public interface IStoryRepository
    {
        StoryDefinition GetStoryByName(string name);
    }
}