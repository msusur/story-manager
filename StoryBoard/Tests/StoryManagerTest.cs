using Moq;
using StoryBoard2.Entities;
using Xunit;

namespace StoryBoard2.Tests
{
    public class StoryManagerTest
    {
        private readonly StoryDefinition _dummyStoryDefinition = new StoryDefinition();

        [Fact]
        // ReSharper disable InconsistentNaming
        public void Story_manager_gets_story_definition_from_repository()
        // ReSharper restore InconsistentNaming
        {
            var storyManager = TestableStoryManager.Create(_dummyStoryDefinition);
            var result = storyManager.ExecuteStory(new StoryContext(), "test");
            //Assert.True(result.Value == "My Value");
            storyManager.StoryRepository
                .Verify(storyRepository => storyRepository.GetStoryByName(It.IsAny<string>()), Times.AtLeastOnce());
        }
        [Fact]
        // ReSharper disable InconsistentNaming
        public void Story_manager_executes_next_story_node()
        // ReSharper restore InconsistentNaming
        {
            var definition = new StoryDefinition("test", 
                                    new StoryNode("Node1"));
            var storyManager = TestableStoryManager.Create(_dummyStoryDefinition);
            var result = storyManager.ExecuteStory(new StoryContext(), "test");

        }
    }
}
