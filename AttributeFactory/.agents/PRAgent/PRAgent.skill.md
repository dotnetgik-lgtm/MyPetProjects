# PR Agent Skills

Skills this agent exposes to maintainers and IDE integration:

- summarize-pr: Produce a clear PR summary with changed files, key diffs, and risk assessment.
- suggest-review-comments: Given a set of changed files or a diff, produce inline review comments and suggested code fixes.
- run-build-and-tests: Provide commands to run `dotnet build` and `dotnet test`, and interpret common failures. (Agent will not run commands automatically without explicit user action.)
- recommend-reviewers: Recommend reviewers based on changed file paths and repository structure.
- generate-pr-description: Create a ready-to-use PR description including summary, test results, and reviewers.

Examples:
- `summarize-pr --pr-number 12`
- `suggest-review-comments --files Senders/EmailSender.cs`
- `run-build-and-tests`
- `recommend-reviewers --files AttributeFactory.cs, Senders/SmsSender.cs`

Notes:
- Keep suggestions minimal and actionable.
- Prefer tests-first suggestions when proposing code changes.
