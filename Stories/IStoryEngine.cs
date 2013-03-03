using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoryNode.Activities.Results;
using StoryNode.Models;

namespace StoryNode
{
   public interface IStoryEngine
    {
       ActivityResult ExecuteStory(Story selectedStory, object parameter);
    }
}
