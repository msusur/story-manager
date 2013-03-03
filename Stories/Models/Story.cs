using System.Collections.Generic;
using StoryNode.Conditions;

namespace StoryNode.Models
{
    public class Story
    {
        public string Name { get; set; }
        public IList<Step> Steps { get; set; }

        public ICondition Condition { get; set; }
    }
}