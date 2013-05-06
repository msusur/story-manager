using StoryBoard.Entities;
using StoryBoard.Entities.Conditions;

namespace StoryBoard.Tests.TestEntities
{
    public class TestCondition : ConditionBase
    {
        private readonly string _propertyName;
        private readonly object _value;

        public TestCondition(string nodeName, string propertyName, object value)
            : base(nodeName)
        {
            _propertyName = propertyName;
            _value = value;
        }

        public override bool CanExecute(StoryContext context)
        {
            return true;
        }
    }
}
