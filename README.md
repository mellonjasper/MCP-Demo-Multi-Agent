# MCP-DemoApi

Project-level README for the MCP-DemoApi repository. This repo demonstrates an MCP server, a companion Web API, and an n8n workflow used to exercise the services. The project is designed to run in Docker (via `docker-compose`) or locally with the .NET 10 SDK.

## Project layout
- `McpServer/` — MCP application (scaffolded from `dotnet new mcpserver`).
- `McpServer/Tools/` — helper tools referenced by the MCP server.
- `Api/` — Web API (scaffolded from `dotnet new webspi`).
- `Domain/Services/` — Domain model and services used by the API and MCP server.
- `n8n/` — n8n workflow export (`Demo workflow.json`) used to integrate with the MCPServer.
- `docker-compose.yml` — composes the containers using custom `Dockerfile`s in the service folders.

## Key prerequisites
- .NET 10 SDK — required for local development and testing. Verify with:

  dotnet --list-sdks

- Docker Desktop (or equivalent) with Docker Compose support — for containerized runs.
- Groq Console API key — obtain from https://console.groq.com/keys (add it to n8n credentials or environment variables used by the workflow).

## How this repo was initially scaffolded (author notes)
- Install MCP server templates (one-time):

  dotnet new install Microsoft.McpServer.ProjectTemplates

- Scaffold the MCP server (example):

  dotnet new mcpserver -n McpServer

- Scaffold the API (example used by the author):

  dotnet new webspi -n Api

* The repository uses custom `Dockerfile`s rather than the templates' defaults; `docker-compose.yml` references them.

## Running the entire application (recommended): Docker Compose
From the repository root run:

```powershell
docker compose up --build
```

This builds images from each service's `Dockerfile` and starts the containers described in `docker-compose.yml`.

Common compose commands:
- Build all images: `docker compose build`
- Build a single service: `docker compose build <service>`
- Stop and remove containers: `docker compose down`
- View logs: `docker compose logs --follow`

Note: On Windows ensure Docker Desktop is running and you have sufficient resources (CPU, memory) allocated.

## Running services locally (no Docker)
1. Ensure .NET 10 SDK is installed.
2. Start the API:

```powershell
cd Api
dotnet run
```

3. Start the MCP server in a separate terminal:

```powershell
cd McpServer
dotnet run
```

Local runs are convenient while developing; Docker provides a more production-like environment and is recommended for integration testing.

## n8n workflow: import & configuration
1. Open your n8n instance (self-hosted or cloud) and import `n8n/Demo workflow.json`.
2. Configure credentials / environment variables used by the workflow. The workflow requires a Groq API key from https://console.groq.com/keys — store it in n8n credentials or as an environment variable and reference it in the workflow's nodes.
3. Set the API base URL in any HTTP nodes to the running API address (for Docker compose use the service name/port, otherwise `http://localhost:<port>`).
4. Activate or trigger the workflow to test end-to-end interactions.

## Configuration and environment variables
- Inspect `Api/appsettings.json` and `McpServer/appsettings.json` for settings and ports.
- `docker-compose.yml` may reference environment variables; consider creating a `.env` at the project root for local compose overrides.

Suggested `.env` entries (example):

```
# API_URL=http://localhost:5000
# GROQ_API_KEY=your-groq-key-here
```

## Troubleshooting
- If `docker compose up --build` fails, run:

  docker compose logs --follow

- If a container cannot connect to another service, verify service names and ports in `docker-compose.yml` and that the calling service uses the compose network hostname (service name).
- If local `dotnet run` fails, confirm .NET 10 is installed and `dotnet restore` completes successfully.

## Where to look for code
- API controllers: `Api/Controllers/`
- Domain logic and services: `Domain/` and `Domain/Services/`
- MCP server: `McpServer/` (entrypoint `Program.cs`)
- Tools used by MCP server: `Tools/`
- n8n workflow export: `n8n/Demo workflow.json`

## Next steps (optional)
- Add a `.env.example` with the required environment variables.
- Add small helper scripts in the repo root to run Docker Compose or start services locally.
- Wire a CI job to build and smoke-test the compose stack.

## n8n MCP client setup

To add the MCP client in n8n, use the SSE URL: http://mcp-csharp:8080/sse and select the necessary tools in the client configuration. If you run the MCP server outside Docker, replace the Docker service name with `localhost` (for example: http://localhost:8080/sse).

Open n8n in your browser at http://localhost:5678/.

To login user the following:
email: test@test.test
password: Test1234

If the project is properly configured you should see the n8n setup shown below:

![n8n setup](/n8n/n8n.png)




