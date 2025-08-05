# Todo App .NET Core

A sample Todo API built with .NET Core 8.0 for testing DevContainer setup in the C# DevOps journey.

## Project Structure

```
TodoApp/
├── .devcontainer/
│   └── devcontainer.json          # DevContainer configuration
├── TodoApi/                       # Main API project
│   ├── Controllers/
│   │   └── TodosController.cs     # REST API endpoints
│   ├── Models/
│   │   └── TodoItem.cs           # Todo data model
│   ├── Services/
│   │   └── TodoService.cs        # Business logic
│   └── Program.cs                # Application entry point
├── TodoApi.Tests/                 # Unit tests
│   └── TodoServiceTests.cs       # Service layer tests
└── TodoApp.sln                   # Solution file
```

## Features

- ✅ Full CRUD operations for Todo items
- ✅ RESTful API design
- ✅ Swagger/OpenAPI documentation
- ✅ Unit tests with xUnit
- ✅ Health check endpoint
- ✅ DevContainer ready
- ✅ Logging integration

## API Endpoints

### Todos
- `GET /api/todos` - Get all todos
- `GET /api/todos/{id}` - Get specific todo
- `POST /api/todos` - Create new todo
- `PUT /api/todos/{id}` - Update todo
- `PATCH /api/todos/{id}/toggle` - Toggle completion status
- `DELETE /api/todos/{id}` - Delete todo

### Health
- `GET /health` - Health check

## Getting Started with DevContainer

1. **Prerequisites:**
   - Docker Desktop installed and running
   - VS Code with "Dev Containers" extension

2. **Open in DevContainer:**
   - Open this folder in VS Code
   - When prompted, click "Reopen in Container"
   - Or use Command Palette → "Dev Containers: Reopen in Container"

3. **Build and Run:**
   ```bash
   # Navigate to the API project
   cd TodoApi
   
   # Restore dependencies
   dotnet restore
   
   # Run the application
   dotnet run
   ```

4. **Access the API:**
   - Swagger UI: http://localhost:5000 (redirects to Swagger)
   - API Base: http://localhost:5000/api/todos
   - Health Check: http://localhost:5000/health

## Testing

```bash
# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --verbosity normal

# Run tests for specific project
dotnet test TodoApi.Tests/
```

## Sample API Calls

### Get all todos
```bash
curl -X GET "http://localhost:5000/api/todos"
```

### Create a new todo
```bash
curl -X POST "http://localhost:5000/api/todos" \
  -H "Content-Type: application/json" \
  -d '{"title": "Learn Docker", "description": "Master containerization"}'
```

### Toggle todo completion
```bash
curl -X PATCH "http://localhost:5000/api/todos/1/toggle"
```

## Development Features

The DevContainer includes:
- .NET 8.0 SDK
- C# extensions for VS Code
- Azure CLI and tools
- Docker support
- GitHub Copilot integration
- Testing tools

## Next Steps

- Add Entity Framework for database persistence
- Implement authentication and authorization
- Add Docker support for deployment
- Set up CI/CD pipeline
- Deploy to Azure

## Architecture

This is a simple 3-layer architecture:
- **Controllers**: Handle HTTP requests/responses
- **Services**: Business logic and data operations
- **Models**: Data transfer objects and entities

The project uses in-memory storage for simplicity but can be easily extended with Entity Framework and a real database.

## Testing in GitHub Codespaces

GitHub Codespaces provides a cloud-based development environment that works seamlessly with your DevContainer configuration. Here's how to test this Todo API application in Codespaces:

### 1. Create a Codespace

**Method 1: From GitHub Repository**
1. Navigate to your repository on GitHub
2. Click the green **"Code"** button
3. Select the **"Codespaces"** tab
4. Click **"Create codespace on main"** (or your default branch)

**Method 2: From GitHub.dev**
1. Press `.` (period) when viewing your repository on GitHub
2. This opens the repository in github.dev
3. Click **"Continue working in..."** → **"GitHub Codespaces"**

**Method 3: Direct URL**
```
https://github.com/codespaces/new?hide_repo_select=true&ref=main&repo=YOUR_REPO_ID
```

### 2. Automatic DevContainer Setup

Once your Codespace starts:
- GitHub automatically detects the `.devcontainer/devcontainer.json` file
- The container builds with all the configured extensions and tools
- .NET 8.0 SDK, Azure CLI, Docker, and VS Code extensions are pre-installed
- The environment is ready for development in 2-3 minutes

### 3. Build and Test the Application

Open the integrated terminal in Codespaces and run:

```bash
# Verify .NET installation
dotnet --version

# Restore dependencies for the entire solution
dotnet restore

# Build the solution
dotnet build

# Run all tests to verify everything works
dotnet test --verbosity normal
```

### 4. Run the Application

```bash
# Navigate to the API project
cd TodoApi

# Start the application
dotnet run
```

**Expected Output:**
```
Building...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

### 5. Access the Application

GitHub Codespaces automatically handles port forwarding:

**Option 1: Use the Ports Panel**
1. In VS Code, open the **"Ports"** panel (usually at the bottom)
2. You'll see port `5000` and `5001` automatically forwarded
3. Click the **"Open in Browser"** icon next to port 5000
4. This opens the Swagger UI in a new browser tab

**Option 2: Use the Pop-up Notification**
- When the app starts, Codespaces shows a notification: *"Your application running on port 5000 is available"*
- Click **"Open in Browser"** in the notification

**Option 3: Manual URL Construction**
```
https://YOUR_CODESPACE_NAME-5000.app.github.dev
```
Replace `YOUR_CODESPACE_NAME` with your actual codespace name (visible in the URL bar).

### 6. Test the API Endpoints

Once the application is accessible, you can test it several ways:

**Using Swagger UI (Recommended)**
- The root URL automatically redirects to Swagger
- Interactive documentation with "Try it out" buttons
- Test all endpoints directly from the browser

**Using the Integrated Terminal**
```bash
# Test health endpoint
curl http://localhost:5000/health

# Get all todos
curl http://localhost:5000/api/todos

# Create a new todo
curl -X POST http://localhost:5000/api/todos \
  -H "Content-Type: application/json" \
  -d '{"title": "Test in Codespaces", "description": "Testing the API in GitHub Codespaces"}'

# Get the new todo (assuming it gets ID 4)
curl http://localhost:5000/api/todos/4

# Toggle completion status
curl -X PATCH http://localhost:5000/api/todos/4/toggle

# Update the todo
curl -X PUT http://localhost:5000/api/todos/4 \
  -H "Content-Type: application/json" \
  -d '{"title": "Updated in Codespaces", "description": "Successfully updated via API", "isCompleted": true}'

# Delete the todo
curl -X DELETE http://localhost:5000/api/todos/4
```

**Using External Tools**
- Copy the public URL from the Ports panel
- Use Postman, Insomnia, or any REST client
- Test from your local machine or other services

### 7. Development and Debugging

**Start Debugging:**
1. Open `TodoApi/Controllers/TodosController.cs`
2. Set a breakpoint (click left margin of any line)
3. Press `F5` or go to **Run and Debug** → **"Launch TodoApi"**
4. Use the Swagger UI to trigger the breakpoint

**Hot Reload for Development:**
```bash
# Use watch mode for automatic rebuilds
cd TodoApi
dotnet watch run
```

**Run Specific Tests:**
```bash
# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"

# Run tests for a specific class
dotnet test --filter "TodoServiceTests"

# Run a specific test method
dotnet test --filter "GetAllTodosAsync_ShouldReturnInitialTodos"
```

### 8. Codespaces-Specific Features

**Pre-built Environments:**
- Your DevContainer configuration ensures consistent environments
- All team members get identical setups
- Extensions and settings are automatically configured

**Collaboration:**
- Share your Codespace URL with team members for real-time collaboration
- Multiple people can work in the same environment simultaneously

**GitHub Integration:**
- Automatically connected to your GitHub account
- Push/pull changes directly from the integrated terminal
- Access to GitHub CLI (`gh`) for repository management

**Performance:**
- Codespaces provides 2-4 CPU cores and 4-8GB RAM
- Sufficient for .NET development and testing
- Faster than many local development setups

### 9. Troubleshooting

**If the application doesn't start:**
```bash
# Check if port is already in use
netstat -tlnp | grep :5000

# Try a different port
dotnet run --urls "http://localhost:5001"
```

**If ports aren't forwarded:**
1. Open the **Ports** panel in VS Code
2. Click **"Forward a Port"**
3. Enter `5000` and press Enter
4. Set visibility to **"Public"** if you want external access

**If tests fail:**
```bash
# Clean and rebuild
dotnet clean
dotnet build
dotnet test
```

**If DevContainer doesn't load:**
- Check `.devcontainer/devcontainer.json` for syntax errors
- Rebuild the container: Command Palette → **"Codespaces: Rebuild Container"**

### 10. Best Practices for Codespaces

- **Commit frequently** - Codespaces can be stopped/deleted
- **Use the integrated terminal** for all .NET commands
- **Leverage port forwarding** for testing APIs
- **Take advantage of pre-built environments** for consistency
- **Use Secrets** for any API keys or sensitive configuration

## Getting Started with DevContainer
