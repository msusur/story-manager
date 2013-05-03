using System;

namespace StoryBoard2.Entities
{
    public abstract class Activity
    {
        public ActivityResultWrapper Execute(StoryContext context)
        {
            try
            {
                BeforeActivityExecuting(context);
                var result = OnExecutingActivity(context);
                AfterActivityExecution(context);
                return result;
            }
            catch (Exception ex)
            {
                var isHandled = OnActivityException(context, ex);
                if (!isHandled)
                {
                    throw new ActivityExecutionFailedException(context);
                }
            }
            return ActivityResultWrapper.Empty;
        }

        protected virtual bool OnActivityException(StoryContext context, Exception exception)
        {
            return false;
        }

        protected abstract ActivityResultWrapper OnExecutingActivity(StoryContext context);

        protected virtual void AfterActivityExecution(StoryContext context)
        {

        }

        protected virtual void BeforeActivityExecuting(StoryContext context)
        {
        }
    }
}