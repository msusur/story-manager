using Moq;
using StoryBoard.Abstractions;
using StoryBoard.Entities;

namespace StoryBoard.Tests
{
    public class TestableStoryManager : StoryManager
    {
        public Mock<IStoryRepository> StoryRepository { get; private set; }
        public Mock<IStoryExecutor> StoryExecutor { get; private set; }

        private TestableStoryManager(Mock<IStoryRepository> storyRepository, Mock<IStoryExecutor> storyExecutor)
            : base(storyRepository.Object, storyExecutor.Object)
        {
            StoryRepository = storyRepository;
            StoryExecutor = storyExecutor;
        }

        private TestableStoryManager(Mock<IStoryRepository> storyRepository, IStoryExecutor storyExecutor)
            : base(storyRepository.Object, storyExecutor)
        {
            StoryRepository = storyRepository;
        }
        public static TestableStoryManager Create(StoryDefinition definition = null)
        {
            var mock = new Mock<IStoryExecutor>();
            var testable = Create(mock.Object, definition);
            testable.StoryExecutor = mock;
            return testable;
        }
        public static TestableStoryManager Create(IStoryExecutor executor, StoryDefinition defaultDefinition = null)
        {
            var storyRepository = new Mock<IStoryRepository>();
            if (defaultDefinition != null)
            {
                storyRepository.Setup(repository => repository.GetStoryByName(It.IsAny<string>()))
                               .Returns(defaultDefinition);
            }

            var testableStoryManager = new TestableStoryManager(storyRepository, executor);
            return testableStoryManager;
        }
    }
}
