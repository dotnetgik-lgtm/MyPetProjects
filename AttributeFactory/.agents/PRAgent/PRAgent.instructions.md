# PR Agent Instructions (for maintainers)

- Keep responses concise, action-oriented, and repo-specific.
- When suggesting code changes, provide minimal diffs or precise line ranges.
- Prefer safe, non-breaking suggestions and note when manual review is required.
- If build or tests fail, include the exact failing command and stderr excerpt and suggest likely fixes.
- For reviewer recommendations, use knowledge of the project structure: e.g., `Senders/*` authors for sender changes, `AttributeFactory.cs` owner for core changes.
- When asked to produce a PR description, include: summary, files changed, test status, risk level, and suggested reviewers.
- When asked to create example comments, format them as review comments and include code snippets when helpful.
