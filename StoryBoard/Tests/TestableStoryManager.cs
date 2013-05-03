using Moq;
using StoryBoard2.Abstractions;
using StoryBoard2.Entities;

namespace StoryBoard2.Tests
{
    public class TestableStoryManager : StoryManager
    {
        public readonly Mock<IStoryRepository> StoryRepository;
        public readonly Mock<IStoryExecutor> StoryExecutor;

        private TestableStoryManager(Mock<IStoryRepository> storyRepository, Mock<IStoryExecutor> storyExecutor)
            : base(storyRepository.Object, storyExecutor.Object)
        {
            StoryRepository = storyRepository;
            StoryExecutor = storyExecutor;
        }

        public static TestableStoryManager Create(StoryDefinition defaultDefinition = null)
        {
            var storyRepository = new Mock<IStoryRepository>();
            if (defaultDefinition != null)
            {
                storyRepository.Setup(repository => repository.GetStoryByName(It.IsAny<string>()))
                               .Returns(defaultDefinition);
            }
            var storyExecutor = new Mock<IStoryExecutor>();
            var testableStoryManager = new TestableStoryManager(storyRepository,storyExecutor);
            return testableStoryManager;
        }
    }
}
