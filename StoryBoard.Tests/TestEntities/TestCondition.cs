using System;
using StoryBoard.Entities;
using StoryBoard.Entities.Conditions;

namespace StoryBoard.Tests.TestEntities
{
    public class TestCondition : ConditionBase
    {
        private readonly Func<bool> _func;

        public TestCondition(string nodeName, Func<bool> func)
            : base(nodeName)
        {
            _func = func;
        }

        public override bool CanExecute(StoryContext context)
        {
            return _func();
        }
    }
}
