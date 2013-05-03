using System;
using StoryBoard2.Abstractions;
using StoryBoard2.Entities;
using StoryBoard2.Exceptions;

namespace StoryBoard2
{
    public class StoryManager : IStoryManager
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IStoryExecutor _storyExecutor;

        public StoryManager(IStoryRepository storyRepository, IStoryExecutor storyExecutor)
        {
            _storyRepository = storyRepository;
            _storyExecutor = storyExecutor;
        }

        public StoryResult ExecuteStory(StoryContext context, string storyName)
        {
            return ExecuteStory(context, storyName, string.Empty);
        }

        public StoryResult ExecuteStory(StoryContext context, string storyName, string storyNode)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(storyName))
            {
                throw new ArgumentNullException("storyName");
            }
            var definition = _storyRepository.GetStoryByName(storyName);
            if (definition == null)
            {
                throw new StoryDefinitionNotFoundException(storyName);
            }

            var storyResult = _storyExecutor.Next(definition, storyNode);

            return storyResult;
        }
    }
}