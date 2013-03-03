namespace StoryNode
{
    public interface IStoryContext
    {
        string StoryName { get; set; }
        string CurrentActivity { get; set; }
        object Parameter { get; set; }
    }
}