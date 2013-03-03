using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using StoryNode;
using StoryNode.Activities.Results;
using StoryNode.Conditions;
using StoryNode.Models;

namespace Stories.Tests
{
    [TestFixture]
    public class StoriesTests
    {
        private IEnumerable<Story> Stories
        {
            get
            {
                return new List<Story>
                           {
                              new Story {
                                  Condition = new RelayCondition(_ => _.IsTrue == true),
                                  Name = "IsTrueStory",
                                  Steps = new List<Step>
                                              {
                                                  new Step
                                                      {
                                                          Condition = new RelayCondition(_ => _.IsTrue == true),
                                                          Activities = new List<ActivityBase>
                                                                           {
                                                                               new ReturnTrueActivity()
                                                                           }
                                                      }
                                              }
                              },

                           };
            }
        }

        [Test]
        public void CanUserAConditionStartsTheStory()
        {
            var manager = TestableStoryManager.Create(Stories.ToArray());
            manager.EngineMock.Setup(engine => engine.ExecuteStory(It.IsAny<Story>(), It.IsAny<object>())).Returns(() => new ActivityModelResult<FooResultModel>(new FooResultModel { Result = true }));
            var result = manager.StartStory("IsTrueStory", new { IsTrue = true });
            Assert.IsAssignableFrom<FooResultModel>(result);
            var fooResultModel = result as FooResultModel;
            Assert.IsTrue(fooResultModel != null && fooResultModel.Result);
        }
    }

    internal class ReturnTrueActivity : ActivityBase
    {
        public override ActivityResult ExecuteActivity(IStoryContext context)
        {
            return new ActivityModelResult<FooResultModel>(new FooResultModel { Result = true });
        }
    }

    internal class FooResultModel
    {
        public bool Result { get; set; }
    }
}
