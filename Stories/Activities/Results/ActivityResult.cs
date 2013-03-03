using System;
using StoryNode.Models;

namespace StoryNode.Activities.Results
{
    public abstract class ActivityResult
    {
        public string ActivityName { get; set; }
        public string StepName { get; set; }

        public object Execute(IStoryContext context)
        {
            try
            {
                var result = OnExecuting(context);
                AfterExecuting(context);
                return result;
            }
            catch (Exception ex)
            {
                var errorStoryContext = new ErrorStoryContext(context, ex);
                OnError(errorStoryContext);
                if (errorStoryContext.Handled)
                {
                    return null;
                }
                throw;
            }
        }

        protected virtual void OnError(ErrorStoryContext errorStoryContext)
        {
            
        }

        protected virtual void AfterExecuting(IStoryContext context)
        {

        }

        protected virtual object OnExecuting(IStoryContext context)
        {
            return null;
        }
    }
}
