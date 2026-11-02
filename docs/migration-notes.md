# Selected migration notes

## Reporting flow

1. Choose a reporting source and retrieve its field metadata.
2. Move fields between the available and selected lists.
3. Save the report name, description, constant metadata, source, and comma-separated field names.
4. Load a saved definition and validate selected names against the reporting metadata.
5. Execute a query for those columns and render a dynamic table with readable captions.

The stored constant has no calculation applied in the reviewed reporting path.

## Problems addressed

| Problem | Change |
| --- | --- |
| Customer login returned to the form | Made non-input model properties nullable to avoid unintended required validation |
| Field names appeared as undefined | Established matching value/text names in the JSON endpoint and JavaScript |
| Report cells displayed False | Replaced value-to-field-name comparisons with actual column retrieval |
| Generated SQL was never executed | Added a repository query method and connected it to the report action |
| Saved fields disappeared from editing | Loaded saved selections separately from remaining available fields |
| Newly moved options were not persisted | Selected all destination options before submitting the edit form |
| Report controller could not be activated | Registered the report repository with scoped dependency injection |

## Scope of excerpts

The samples are extracted from the supplied migration milestone. They retain original internal names to show continuity with the legacy implementation. They omit host classes and dependencies rather than introducing deliberate defects into a complete application.

The query excerpt allows three source tables and validates identifier syntax. Its controller caller also checks field names against the report metadata. The repository excerpt must not be treated as a complete independent security boundary or deployed by itself.

## Further development

- Complete specialized calculation workflows.
- Verify reporting across every supported source.
- Review server-side report input validation and selected-field storage limits.
- Modernize legacy authentication and perform broader deployment testing.

## Verification

The developer confirmed local execution of document-data reports and report editing. No .NET build or database integration test was performed in the publication environment; this repository intentionally excludes the executable application.
