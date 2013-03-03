using System.Collections.Generic;
using Moq;
using StoryNode;
using StoryNode.Models;

namespace Stories.Tests
{
    class TestableStoryManager : StoryManager
    {
        public readonly Mock<IStoryRepository> StoryRepoMock;
        public readonly Mock<IStoryEngine> EngineMock;

        TestableStoryManager(Mock<IStoryRepository> storyRepoMock, Mock<IStoryEngine> engineMock)
            : base(storyRepoMock.Object, engineMock.Object)
        {
            StoryRepoMock = storyRepoMock;
            EngineMock = engineMock;
        }

        public static TestableStoryManager Create(params Story[] stories)
        {
            var storyRepoMock = new Mock<IStoryRepository>();
            storyRepoMock.Setup(repository => repository.LoadStories()).Returns(stories);
            var engineMock = new Mock<IStoryEngine>();
            return new TestableStoryManager(storyRepoMock, engineMock);
        }
    }
}
