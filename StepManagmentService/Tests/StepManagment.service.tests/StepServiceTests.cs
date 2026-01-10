using Journify.core.Entities;
using Journify.service.Interfaces;
using Journify.service.usecases;
using Moq;
using Xunit;

namespace Journify.service.tests
{
    public class StepServiceTests
    {
        private readonly Mock<IStepRepository> _stepRepositoryMock;
        private readonly StepService _stepServiceMock;
        // Test methods for StepService would go here

        public StepServiceTests()
        {
            _stepRepositoryMock = new Mock<IStepRepository>();
            _stepServiceMock = new StepService(_stepRepositoryMock.Object);
        }
        [Fact]
        public async Task GetAllStepsAsync_ShouldReturnSteps()
        {
            // Arrange
            var expectedSteps = new List<Step>
            {
                new Step
                {
                    Id = Guid.NewGuid(),
                    DailyJourneyId = Guid.NewGuid(),
                    Title = "Step 1",
                    Description = "Description 1",
                    IsCompleted = false,
                    CreatedAt = DateTime.UtcNow,
                    LastUpdatedAt = DateTime.UtcNow
                },
                new Step
                {
                    Id = Guid.NewGuid(),
                    DailyJourneyId = Guid.NewGuid(),
                    Title = "Step 2",
                    Description = "Description 2",
                    IsCompleted = true,
                    CreatedAt = DateTime.UtcNow,
                    LastUpdatedAt = DateTime.UtcNow
                }
            };
            _stepRepositoryMock.Setup(repo => repo.GetAllStepsAsync())
                .ReturnsAsync(expectedSteps);
            // Act
            var result = await _stepServiceMock.GetAllStepsAsync();
            // Assert
            Assert.Equal(expectedSteps.Count, result.Count());
            Assert.Equal(expectedSteps, result);
        }
        [Fact]
        public async Task GetStepById_ShouldReturnStep()
        {
            // Arrange
            var stepId = Guid.NewGuid();
            var expectedStep = new Step
            {
                Id = stepId,
                DailyJourneyId = Guid.NewGuid(),
                Title = "Step 1",
                Description = "Description 1",
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            };
            _stepRepositoryMock.Setup(repo => repo.GetStepById(stepId))
                .ReturnsAsync(expectedStep);
            // Act
            var result = await _stepServiceMock.GetStepById(stepId);
            // Assert
            Assert.Equal(expectedStep, result);
        }
        [Fact]
        public async Task AddStepAsync_ShouldAddAndReturnStep()
        {
            // Arrange
            var newStep = new Step
            {
                DailyJourneyId = Guid.NewGuid(),
                Title = "New Step",
                Description = "New Description",
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            };
            _stepRepositoryMock.Setup(repo => repo.AddStepAsync(newStep))
                .ReturnsAsync(newStep);
            // Act
            var result = await _stepServiceMock.AddStepAsync(newStep);
            // Assert
            Assert.Equal(newStep, result);
        }
    }
}
