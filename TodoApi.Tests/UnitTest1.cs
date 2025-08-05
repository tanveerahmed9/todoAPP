using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Tests;

public class TodoServiceTests
{
    [Fact]
    public async Task GetAllTodosAsync_ShouldReturnInitialTodos()
    {
        // Arrange
        var todoService = new TodoService();

        // Act
        var todos = await todoService.GetAllTodosAsync();

        // Assert
        Assert.NotNull(todos);
        Assert.Equal(3, todos.Count()); // Should have 3 initial todos
    }

    [Fact]
    public async Task CreateTodoAsync_ShouldCreateNewTodo()
    {
        // Arrange
        var todoService = new TodoService();
        var newTodo = new TodoItem
        {
            Title = "Test Todo",
            Description = "Test Description"
        };

        // Act
        var createdTodo = await todoService.CreateTodoAsync(newTodo);

        // Assert
        Assert.NotNull(createdTodo);
        Assert.True(createdTodo.Id > 0);
        Assert.Equal("Test Todo", createdTodo.Title);
        Assert.Equal("Test Description", createdTodo.Description);
        Assert.False(createdTodo.IsCompleted);
    }

    [Fact]
    public async Task GetTodoByIdAsync_WithValidId_ShouldReturnTodo()
    {
        // Arrange
        var todoService = new TodoService();

        // Act
        var todo = await todoService.GetTodoByIdAsync(1);

        // Assert
        Assert.NotNull(todo);
        Assert.Equal(1, todo.Id);
    }

    [Fact]
    public async Task GetTodoByIdAsync_WithInvalidId_ShouldReturnNull()
    {
        // Arrange
        var todoService = new TodoService();

        // Act
        var todo = await todoService.GetTodoByIdAsync(999);

        // Assert
        Assert.Null(todo);
    }

    [Fact]
    public async Task ToggleTodoAsync_ShouldToggleCompletionStatus()
    {
        // Arrange
        var todoService = new TodoService();
        var initialTodo = await todoService.GetTodoByIdAsync(1);
        var initialStatus = initialTodo?.IsCompleted ?? false;

        // Act
        var toggledTodo = await todoService.ToggleTodoAsync(1);

        // Assert
        Assert.NotNull(toggledTodo);
        Assert.Equal(!initialStatus, toggledTodo.IsCompleted);
    }

    [Fact]
    public async Task DeleteTodoAsync_WithValidId_ShouldReturnTrue()
    {
        // Arrange
        var todoService = new TodoService();

        // Act
        var result = await todoService.DeleteTodoAsync(1);

        // Assert
        Assert.True(result);
        
        // Verify todo is actually deleted
        var deletedTodo = await todoService.GetTodoByIdAsync(1);
        Assert.Null(deletedTodo);
    }

    [Fact]
    public async Task DeleteTodoAsync_WithInvalidId_ShouldReturnFalse()
    {
        // Arrange
        var todoService = new TodoService();

        // Act
        var result = await todoService.DeleteTodoAsync(999);

        // Assert
        Assert.False(result);
    }
}