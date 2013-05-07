using System;

namespace StoryBoard.Exceptions
{
    [Serializable]
    public class ActivityExecutionFailedException : Exception
    {
        public ActivityExecutionFailedException(ActivityContext context)
        {
            
        }
    }
}