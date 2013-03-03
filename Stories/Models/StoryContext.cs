namespace StoryNode
{
    internal class StoryContext : IStoryContext
    {
        public string StoryName { get; set; }

        public string CurrentActivity { get; set; }

        public object Parameter { get; set; }
    }
}