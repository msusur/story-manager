using Moq;
using StoryBoard.Entities;
using StoryBoard.Tests.TestActivities;
using Xunit;

namespace StoryBoard.Tests
{
    public class StoryManagerTest
    {
        private readonly StoryDefinition _dummyStoryDefinition = new StoryDefinition();

        [Fact]
        public void Story_manager_gets_story_definition_from_repository()
        {
            var storyManager = TestableStoryManager.Create(_dummyStoryDefinition);
            var result = storyManager.ExecuteStory(new StoryContext(), "test");
            storyManager.StoryRepository
                .Verify(storyRepository => storyRepository.GetStoryByName(It.IsAny<string>()), Times.AtLeastOnce());
        }

        [Fact]
        public void Story_manager_executes_next_story_node_starts_from_begining()
        {
            var definition = new StoryDefinition("test",
                                    new StoryNode("Node1", new EmptyActivity()),
                                    new StoryNode("Node2", new EmptyActivity())
                                    );
            var storyExecutor = new StoryExecutor();
            var storyManager = TestableStoryManager.Create(_dummyStoryDefinition);

            var result = storyManager.ExecuteStory(new StoryContext(), "test");
            Assert.Equal(result.CurrentStepName, "Node2");
        }
    }
}
