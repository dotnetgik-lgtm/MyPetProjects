# Code Review Agent — Maintainer Instructions

- Be precise and evidence-based. For every issue called out include file path + line range and a short rationale.
- Categorize findings as `critical`, `major`, `minor`, or `suggestion`.
- When proposing fixes, prefer minimal, compile-safe diffs that preserve existing behavior unless the change is explicitly a behavioral improvement.
- Recommend tests for missing behavior or for fixes that close uncovered edge cases.
- Include commands to reproduce build or test failures and the exact outputs (when available).
- For style issues, reference commonly-used C# conventions (Microsoft/StyleCop) and keep suggestions consistent.
- When security concerns are raised, include an explanation and suggested mitigation steps.
