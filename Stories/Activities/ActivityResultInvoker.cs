using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoryNode.Activities.Results;
using StoryNode.Models;

namespace StoryNode
{
    internal static class ActivityResultInvoker
    {
        public static object InvokeResult(ActivityResult result, Story currentStory, object storyParameter)
        {
            return result.Execute(new StoryContext
                                      {
                                          StoryName = currentStory.Name,
                                          CurrentActivity = result.ActivityName,
                                          Parameter = storyParameter
                                      });
        }
    }
}
