# Code Review Agent — Skills

Exposed skills and example usage:

- `full-review --branch feature/xyz` — Run a full review workflow for a branch (requires diff/branch content provided).
- `inline-comments --diff <diff>` — Produce inline review comments for a supplied diff.
- `test-suggestions --files <files>` — Identify missing tests and propose test cases.
- `suggest-diffs --finding-id <id>` — Produce a minimal code diff to address a specific finding.

Behavioral notes:
- Always keep suggested diffs minimal and safe to apply.
- When the codebase exposes unit tests, favor test-driven suggestions.
- Prefer explicit references to `AttributeFactory` files and `Senders/*` when tying reviewers to areas.
