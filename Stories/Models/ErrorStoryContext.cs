using System;

namespace StoryNode.Models
{
    public class ErrorStoryContext : IStoryContext
    {
        public string StoryName
        {
            get { return _context.StoryName; }
            set { _context.StoryName = value; }
        }

        public string CurrentActivity
        {
            get { return _context.CurrentActivity; }
            set { _context.CurrentActivity = value; }
        }

        public object Parameter
        {
            get { return _context.Parameter; }
            set { _context.Parameter = value; }
        }

        public Exception Exception { get; set; }

        public bool Handled { get; set; }

        private readonly IStoryContext _context;

        public ErrorStoryContext(IStoryContext context, Exception exception)
        {
            _context = context;
            Exception = exception;
        }

    }
}