using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryNode.Conditions
{
    public class RelayCondition : ICondition
    {
        private readonly Func<dynamic, bool> _condition;

        public RelayCondition(Func<dynamic, bool> condition)
        {
            _condition = condition;
        }

        public bool CanStart(dynamic param)
        {
            return _condition(param);
        }
    }

    public interface ICondition
    {
        bool CanStart(dynamic param);
    }
}
