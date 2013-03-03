using System.Collections.Generic;
using System.Linq;
using StoryNode.Activities.Results;
using StoryNode.Models;

namespace StoryNode
{
    public interface IStoryManager
    {
        object StartStory(string storyName, object parameter = null);
    }

    public class StoryManager : IStoryManager
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IStoryEngine _engine;

        public StoryManager(IStoryRepository storyRepository, IStoryEngine engine)
        {
            _storyRepository = storyRepository;
            _engine = engine;
        }

        public object StartStory(string storyName, object parameter = null)
        {
            var selectedStory = _storyRepository.LoadStories().First(story => story.Name == storyName);
            var result = _engine.ExecuteStory(selectedStory, parameter);
            return ActivityResultInvoker.InvokeResult(result, selectedStory, parameter);
        }
    }

    public interface IStoryRepository
    {
        IEnumerable<Story> LoadStories();
    }
}
