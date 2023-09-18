using ToDoAPI.Models;

namespace ToDoAPI.Tests
{
    public class ToDoModelTests
    {
        [Fact]
        public void CanChangeName()
        {
            // Arrange
            var testToDo = new ToDoItem
            {
                Name = "Complete Unit Test",
                fee = 10.33,
                tax = 20
            };

            // Act
            testToDo.Name = "Complete Azure PipeLine";

            // Assert
            Assert.Equal("Complete Azure PipeLine", testToDo.Name);
        }
    }
}