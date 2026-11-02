# Custom Page Builder — featured work

The Page Builder is a central contribution highlighted by the developer in this project. It lets page administrators compose customer pages from ordered rows, select a predefined column layout for each row, and maintain the content stored in those columns.

## Capabilities represented in the source

- Customer-page context and row ordering through `CustPage_ID` and `PagBC_Row`.
- Twelve predefined column-layout variants, with dedicated content slots.
- Creating, editing, and deleting page rows.
- Rich-text editing integration through CKEditor in the host views.
- A sidebar listing data sources marked for customer use.
- Database persistence through EF Core and a view model for page editing.

These are source-backed capabilities; this portfolio does not claim a generic drag-and-drop framework or a separately verified production deployment.

## Selected implementation

| Sample | Responsibility |
| --- | --- |
| [Create row](../samples/csharp/PageBuilderCreateRow.cs) | Resolve the administrator and page context, validate the input, associate the new row with the customer page, persist it, and redirect |
| [Column-content mapping](../samples/csharp/PageBuilderColumnContent.cs) | Map content slots for the selected layout variant |
| [Sidebar component](../samples/csharp/PageBuilderSidebarComponent.cs) | Retrieve customer-enabled sources, order them, and render the sidebar partial |
| [Razor integration](../samples/razor/PageBuilderSidebar.cshtml) | Invoke the sidebar as an ASP.NET Core ViewComponent |

## MVC 5 to Core migration

The sidebar uses `Component.InvokeAsync("TableListSide")` and a ViewComponent with an injected database context. The component explicitly renders the existing `P_TableListSide.cshtml` partial, so no separate `Default.cshtml` is required by this implementation.

The selected controller reads the page identifier from a session string using `long.TryParse`, matching the string stored when opening the editor. Page rows are supplied to the editor through `PageItems`, ordered by row number.

The controller also separates page access checks, layout loading, entity/view-model mapping, and column-content assignment into helpers. The excerpts retain the original names and mapping approach; they are extracts of the implementation rather than a redesigned replacement.

## Portfolio scope

Only selected methods and one layout integration line are included. The full controller, editor forms, entity definitions, rendering templates, database, and client assets are withheld. Dependencies referenced by the excerpts are intentionally absent; this is a case study, not a runnable Page Builder distribution.
