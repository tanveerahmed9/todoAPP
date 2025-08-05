using TodoApi.Models;

namespace TodoApi.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetAllTodosAsync();
        Task<TodoItem?> GetTodoByIdAsync(int id);
        Task<TodoItem> CreateTodoAsync(TodoItem todo);
        Task<TodoItem?> UpdateTodoAsync(int id, TodoItem todo);
        Task<bool> DeleteTodoAsync(int id);
        Task<TodoItem?> ToggleTodoAsync(int id);
    }

    public class TodoService : ITodoService
    {
        private readonly List<TodoItem> _todos = new();
        private int _nextId = 1;

        public TodoService()
        {
            // Add some sample data
            _todos.AddRange(new[]
            {
                new TodoItem { Id = _nextId++, Title = "Learn .NET Core", Description = "Complete the .NET Core tutorial", IsCompleted = false },
                new TodoItem { Id = _nextId++, Title = "Set up DevContainer", Description = "Configure development environment", IsCompleted = true, CompletedAt = DateTime.UtcNow.AddHours(-1) },
                new TodoItem { Id = _nextId++, Title = "Build Todo API", Description = "Create a RESTful API for todo management", IsCompleted = false }
            });
        }

        public Task<IEnumerable<TodoItem>> GetAllTodosAsync()
        {
            return Task.FromResult(_todos.AsEnumerable());
        }

        public Task<TodoItem?> GetTodoByIdAsync(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            return Task.FromResult(todo);
        }

        public Task<TodoItem> CreateTodoAsync(TodoItem todo)
        {
            todo.Id = _nextId++;
            todo.CreatedAt = DateTime.UtcNow;
            _todos.Add(todo);
            return Task.FromResult(todo);
        }

        public Task<TodoItem?> UpdateTodoAsync(int id, TodoItem updatedTodo)
        {
            var existingTodo = _todos.FirstOrDefault(t => t.Id == id);
            if (existingTodo == null)
                return Task.FromResult<TodoItem?>(null);

            existingTodo.Title = updatedTodo.Title;
            existingTodo.Description = updatedTodo.Description;
            existingTodo.IsCompleted = updatedTodo.IsCompleted;
            
            if (updatedTodo.IsCompleted && existingTodo.CompletedAt == null)
                existingTodo.CompletedAt = DateTime.UtcNow;
            else if (!updatedTodo.IsCompleted)
                existingTodo.CompletedAt = null;

            return Task.FromResult<TodoItem?>(existingTodo);
        }

        public Task<bool> DeleteTodoAsync(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
                return Task.FromResult(false);

            _todos.Remove(todo);
            return Task.FromResult(true);
        }

        public Task<TodoItem?> ToggleTodoAsync(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
                return Task.FromResult<TodoItem?>(null);

            todo.IsCompleted = !todo.IsCompleted;
            todo.CompletedAt = todo.IsCompleted ? DateTime.UtcNow : null;

            return Task.FromResult<TodoItem?>(todo);
        }
    }
}
