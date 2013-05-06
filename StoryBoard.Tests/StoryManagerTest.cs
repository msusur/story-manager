using Moq;
using StoryBoard.Entities;
using StoryBoard.Entities.Conditions;
using StoryBoard.Tests.TestActivities;
using StoryBoard.Tests.TestEntities;
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
                                    new StoryNode("Node1", new EmptyActivity(), new EmptyActivity()),
                                    new StoryNode("Node2", new EmptyActivity())
                                    );
            var storyManager = TestableStoryManager.Create(new StoryExecutor(), definition);

            var result = storyManager.ExecuteStory(new StoryContext(), "test");
            Assert.Equal(result.CurrentStepName, "Node1");
        }

        [Fact]
        public void Story_manager_executes_next_story_node_with_condition()
        {
            var definition = new StoryDefinition("test",
                                    new StoryNode("Node1", new EmptyActivity(), new EmptyActivity()),
                                    new StoryNodeGroup("Node2", new TestCondition("Node21", () => false))
                                            .AddCondition(new TestCondition("Node22", () => false))
                                            .AddCondition(new TestCondition("Node23", () => true))
                                            .AddNode(new StoryNode("Node21", new EmptyActivity(), new EmptyActivity()))
                                            .AddNode(new StoryNode("Node22", new EmptyActivity(), new EmptyActivity()))
                                            .AddNode(new StoryNode("Node23", new EmptyActivity(), new EmptyActivity()))
                                    );
            var storyManager = TestableStoryManager.Create(new StoryExecutor(), definition);
            var result = storyManager.ExecuteStory(new StoryContext(), "test", "Node1");
            Assert.Same("Node2", result.CurrentStepName);
        }
    }
}