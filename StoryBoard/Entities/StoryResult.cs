namespace StoryBoard2.Entities
{
    public class StoryResult
    {
        public string CurrentStepName { get; set; }
        public bool IsEnded { get; set; }
        public ActivityResultWrapper Value { get; set; }
    }

    public class ActivityResultWrapper
    {
        public static readonly ActivityResultWrapper Empty = new ActivityResultWrapper();
    }
}