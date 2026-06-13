PR Agent — AttributeFactory

Quick use:
- Open the agent panel or call the agent with a prompt such as:
  - "Summarize changes in my current branch and suggest reviewers"
  - "Suggest review comments for Senders/PushSender.cs"
  - "Create a PR description for my feature branch"

Local checks the agent will recommend (manual):
```powershell
Set-Location 'C:\MyPetProjects\AttributeFactory'
dotnet build
dotnet test
```

Integration notes:
- The agent files live under `.agents/PRAgent` and are intended for IDE/agent tooling integrations (Copilot/Foundry agent customizations).
- The agent does not automatically run commands; it provides recommended commands and interpretations.

Want me to also add a GitHub Actions workflow that runs tests on PRs? Reply and I'll scaffold it.
