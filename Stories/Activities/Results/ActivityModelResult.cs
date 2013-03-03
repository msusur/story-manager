namespace StoryNode.Activities.Results
{
    public class ActivityModelResult<TModelType> : ActivityResult
    {
        public TModelType Model { get; set; }

        public ActivityModelResult(TModelType model)
        {
            Model = model;
        }

        protected override object OnExecuting(IStoryContext context)
        {
            return Model;
        }
    }
}
