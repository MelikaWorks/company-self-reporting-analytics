// Selected excerpt from Controllers/AdminReportController.cs
// Loads a saved definition, checks access and metadata, and prepares column captions.
// Enclosing types and application dependencies are intentionally omitted.

public IActionResult ReportRun(int? id)
        {
            string? email = HttpContext.Session.GetString("Admin_Email");

            if (email == null)
                return RedirectToAction("splogin", "Account");

            var admin = _db.Admin_tbs
                .SingleOrDefault(x => x.Admin_Email == email);

            if (admin == null)
                return RedirectToAction("splogin", "Account");

            if (admin.Role_Id != 1 || admin.Admin_AccessReport != true)
            {
                ViewBag.valid = "شما مجوز دسترسی ندارید";
                return View(new ReportViewModel());
            }

            if (id == null || id <= 0)
                return BadRequest();

            var report = _db.ReportSave1_tbs
                .SingleOrDefault(x => x.RS1_ID == id);

            if (report == null)
                return NotFound();

            var model = new ReportViewModel
            {
                RS1_ID = report.RS1_ID,
                RS1_Name = report.RS1_Name ?? "",
                RS1_Const = report.RS1_Const ?? "",
                RS1_Desc = report.RS1_Desc ?? "",
                RD_TBName = report.RD_TBName ?? "",
                RD_TBNameFa = report.RD_TBNameFa ?? "",
                RD_FildName = report.RD_FildName ?? "",
                Accounts = new System.Data.DataTable()
            };

            var fields = model.RD_FildName.Split(
                ',',
                StringSplitOptions.RemoveEmptyEntries |
                StringSplitOptions.TrimEntries
            ).Distinct().ToArray();

            var definitions = _db.ReportDoc_tbs
                .Where(x => x.RD_TBName == model.RD_TBName)
                .ToList();

            if (fields.Length == 0 ||
                fields.Any(field =>
                    !definitions.Any(x => x.RD_FildName == field)))
            {
                ViewBag.valid = "فیلدهای گزارش معتبر نیستند؛ گزارش را ویرایش کنید.";
                return View(model);
            }

            model.Accounts = _empRepo.ExecuteReport(
                model.RD_TBName,
                fields
            );

            foreach (System.Data.DataColumn column in model.Accounts.Columns)
            {
                var definition = definitions.FirstOrDefault(
                    x => x.RD_FildName == column.ColumnName
                );

                column.Caption =
                    string.IsNullOrWhiteSpace(definition?.RD_FildNameFa)
                        ? column.ColumnName
                        : definition!.RD_FildNameFa!;
            }

            return View(model);
        }
