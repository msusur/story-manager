﻿using System;
using System.Collections.Generic;

namespace StoryBoard2.Entities
{
    [Serializable]
    public class StoryDefinition
    {
        public IList<StoryNode> StoryNodes { get; private set; }

        public string StoryName { get; set; }

        [Obsolete("Dynamic serialization only.")]
        public StoryDefinition()
        {
            
        }

        public StoryDefinition(string storyName, params StoryNode[] storyNodes)
        {
            if (string.IsNullOrEmpty(storyName))
            {
                throw new ArgumentNullException("storyName");
            }
            if (storyNodes == null || storyName.Length < 1)
            {
                throw new ArgumentException("Story must have at least one story node.", "storyNodes");
            }
            StoryNodes = new List<StoryNode>(storyNodes);
            StoryName = storyName;
        }
    }
}