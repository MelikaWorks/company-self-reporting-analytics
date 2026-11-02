// Selected excerpt from Controllers/AdminReportController.cs
// Returns explicit value/text keys for the field-selection UI.
// Enclosing types and application dependencies are intentionally omitted.

public JsonResult GetFild(string RD_TBName)
        {
            var fields = _db.ReportDoc_tbs
                .Where(x => x.RD_TBName == RD_TBName)
                .Select(x => new
                {
                    value = x.RD_FildName,
                    text = x.RD_FildNameFa
                })
                .ToList();

            return Json(fields);
        }
