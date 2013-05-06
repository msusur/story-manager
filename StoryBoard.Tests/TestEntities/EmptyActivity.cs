using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoryBoard.Entities;
using StoryBoard.Entities.Activities;

namespace StoryBoard.Tests.TestActivities
{
    class EmptyActivity : ActivityBase
    {
        protected override ActivityResultWrapper OnExecutingActivity(ActivityContext context)
        {
            return new ActivityResultWrapper();
        }
    }
}
