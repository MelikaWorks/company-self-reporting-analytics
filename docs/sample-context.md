# Selected sample context

These are excerpts from the developer-supplied migrated source, not a runnable application or a security certification. Controller classes, entities, dependency setup, and surrounding views are omitted.

| File | Original location | Scope |
| --- | --- | --- |
| [CustomerActivationGate.cs](../samples/csharp/CustomerActivationGate.cs) | Controllers/AccountController.cs, CLogin POST | Active-account and customer-role checks after credential lookup. Password handling and authentication setup are outside the excerpt. |
| [CustomerPageScope.cs](../samples/csharp/CustomerPageScope.cs) | Controllers/CustomerSelfPageController.cs, CPage | Complete action: session lookup, customer role, name-presence check, and listing pages belonging to that customer. The name check is a legacy proxy for profile completion, not comprehensive validation. This action alone does not prove global enforcement across every endpoint. |
| [DocumentPublicationSelection.cs](../samples/csharp/DocumentPublicationSelection.cs) | Controllers/CustomerPageController.cs, UnPublishDocument GET | Operator role/section permission check and the published-document choices for a page's customer. The POST mutation is not included or verified here. |
| [PublishedMemberData.cshtml](../samples/razor/PublishedMemberData.cshtml) | Views/Home/View.cshtml | Document, financial, and social queries filtered by customer and publication flag; surrounding data/context setup omitted. |
| [PageBuilderDocumentRendering.cshtml](../samples/razor/PageBuilderDocumentRendering.cshtml) | Views/Home/View.cshtml, one-column layout | Original document branch of numeric-token content rendering. It requires the surrounding branch, variables, and published-document query. |

## Reading the Page Builder samples together

Row creation persists the selected layout; column mapping assigns its content; the sidebar explains content-source identifiers. The published-data excerpt selects eligible member records, and the document-rendering excerpt shows one branch of the final presentation.

The original renderer uses numeric-token matching and decoded HTML with Html.Raw. This is presented as an implementation excerpt, not as a hardened HTML-sanitization pattern. No new validation, authorization framework, or rendering rewrite has been invented for the portfolio.

## Documentation versus verification

The [screenshot walkthrough](../screenshots/README.md) records the developer's demonstrated workflows. It includes planned calculation menus with explicit unimplemented labels. Screenshots do not establish backend coverage or successful execution of every workflow.

Only the previously reported developer checks for document-data reports and saved report-field editing are claimed. The new excerpts have been reviewed for their documented scope; they have not been built or integration-tested here.
