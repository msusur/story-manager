using System.Collections.Generic;
using StoryNode.Conditions;

namespace StoryNode.Models
{
    public class Step
    {
        public IList<ActivityBase> Activities { get; set; }

        public ICondition Condition { get; set; }
    }
}