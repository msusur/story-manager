using System;
using StoryBoard.Exceptions;

namespace StoryBoard.Entities.Activities
{
    public abstract class ActivityBase
    {
        public ActivityResultWrapper Execute(ActivityContext context)
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

        protected abstract ActivityResultWrapper OnExecutingActivity(ActivityContext context);
        
        protected virtual bool OnActivityException(ActivityContext context, Exception exception)
        {
            return false;
        }

        protected virtual void AfterActivityExecution(ActivityContext context)
        {

        }

        protected virtual void BeforeActivityExecuting(ActivityContext context)
        {
        }
    }
}