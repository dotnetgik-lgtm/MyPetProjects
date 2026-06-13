Code Review Agent — AttributeFactory

Quick use:
- From your assistant UI or a chat session, ask things like:
  - "Run a full code review on my current branch"
  - "Show inline review comments for changes in Senders/"
  - "List missing tests for recent commits"

Local checks the agent recommends:
```powershell
Set-Location 'C:\MyPetProjects\AttributeFactory'
dotnet build
dotnet test
```

Integration notes:
- Files live under `.agents/CodeReviewAgent` and are intended to be used by IDE-agent integrations.
- Provide the agent with a diff, branch name, or PR number to produce inline comments and suggested diffs.

Would you like me to also: add a `dotnet format` lint step, or scaffold a GitHub Action that runs the code-review checks on PRs? Reply with which you'd prefer.
