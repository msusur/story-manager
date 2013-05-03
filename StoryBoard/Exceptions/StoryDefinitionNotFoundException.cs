using System;

namespace StoryBoard2.Exceptions
{
    public class StoryDefinitionNotFoundException : Exception
    {
        public StoryDefinitionNotFoundException(string storyName)
            : base(string.Format("Story definition for the name '{0}' not found.", storyName))
        {

        }
    }
}