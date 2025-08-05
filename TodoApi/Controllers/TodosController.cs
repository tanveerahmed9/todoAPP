using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly ILogger<TodosController> _logger;

        public TodosController(ITodoService todoService, ILogger<TodosController> logger)
        {
            _todoService = todoService;
            _logger = logger;
        }

        /// <summary>
        /// Get all todo items
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodos()
        {
            _logger.LogInformation("Getting all todos");
            var todos = await _todoService.GetAllTodosAsync();
            return Ok(todos);
        }

        /// <summary>
        /// Get a specific todo item by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodo(int id)
        {
            _logger.LogInformation("Getting todo with ID: {Id}", id);
            var todo = await _todoService.GetTodoByIdAsync(id);
            
            if (todo == null)
            {
                _logger.LogWarning("Todo with ID: {Id} not found", id);
                return NotFound($"Todo with ID {id} not found");
            }

            return Ok(todo);
        }

        /// <summary>
        /// Create a new todo item
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateTodo(CreateTodoRequest request)
        {
            _logger.LogInformation("Creating new todo: {Title}", request.Title);
            
            var todo = new TodoItem
            {
                Title = request.Title,
                Description = request.Description ?? string.Empty
            };

            var createdTodo = await _todoService.CreateTodoAsync(todo);
            return CreatedAtAction(nameof(GetTodo), new { id = createdTodo.Id }, createdTodo);
        }

        /// <summary>
        /// Update an existing todo item
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<TodoItem>> UpdateTodo(int id, UpdateTodoRequest request)
        {
            _logger.LogInformation("Updating todo with ID: {Id}", id);
            
            var todoUpdate = new TodoItem
            {
                Title = request.Title,
                Description = request.Description ?? string.Empty,
                IsCompleted = request.IsCompleted
            };

            var updatedTodo = await _todoService.UpdateTodoAsync(id, todoUpdate);
            
            if (updatedTodo == null)
            {
                _logger.LogWarning("Todo with ID: {Id} not found for update", id);
                return NotFound($"Todo with ID {id} not found");
            }

            return Ok(updatedTodo);
        }

        /// <summary>
        /// Toggle the completion status of a todo item
        /// </summary>
        [HttpPatch("{id}/toggle")]
        public async Task<ActionResult<TodoItem>> ToggleTodo(int id)
        {
            _logger.LogInformation("Toggling todo completion status for ID: {Id}", id);
            
            var todo = await _todoService.ToggleTodoAsync(id);
            
            if (todo == null)
            {
                _logger.LogWarning("Todo with ID: {Id} not found for toggle", id);
                return NotFound($"Todo with ID {id} not found");
            }

            return Ok(todo);
        }

        /// <summary>
        /// Delete a todo item
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(int id)
        {
            _logger.LogInformation("Deleting todo with ID: {Id}", id);
            
            var deleted = await _todoService.DeleteTodoAsync(id);
            
            if (!deleted)
            {
                _logger.LogWarning("Todo with ID: {Id} not found for deletion", id);
                return NotFound($"Todo with ID {id} not found");
            }

            return NoContent();
        }
    }

    // DTOs for request/response
    public record CreateTodoRequest(string Title, string? Description);
    public record UpdateTodoRequest(string Title, string? Description, bool IsCompleted);
}
