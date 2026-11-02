// Selected excerpt from Controllers/AdminReportController.cs
// Loads the saved selection and separates available fields from selected fields.
// Enclosing types and application dependencies are intentionally omitted.

public IActionResult ReportEdit(int? id)
        {
            if (HttpContext.Session.GetString("Admin_Email") == null)
                return RedirectToAction("splogin", "Account");

            string email = HttpContext.Session.GetString("Admin_Email")!;
            var qemail = _db.Admin_tbs.Where(a => a.Admin_Email == email).SingleOrDefault();

            if (qemail == null)
                return RedirectToAction("splogin", "Account");

            // var idd = qemail.Admin_ID;

            if (qemail.Role_Id == 1 && qemail.Admin_AccessReport == true)
            {
                if (id != null && id > 0)
                {
                    ReportSave1_tb? r = _db.ReportSave1_tbs.SingleOrDefault(x => x.RS1_ID == id);
                    if (r == null)
                    {
                        ViewBag.valid = "موردی وجود ندارد";
                        return View();
                    }

                    List<ReportDoc_tb> f = (from p in _db.ReportDoc_tbs
                                            where r.RD_TBName == p.RD_TBName
                                            select p).ToList();

                    var selectedFields = (r.RD_FildName ?? "")
                        .Split(',',
                            StringSplitOptions.RemoveEmptyEntries |
                            StringSplitOptions.TrimEntries)
                        .Distinct()
                        .ToArray();

                    ViewBag.f = new SelectList(
                        f.Where(x => !selectedFields.Contains(x.RD_FildName)),
                        "RD_FildName",
                        "RD_FildNameFa"
                    );

                    ViewBag.SelectedFields = selectedFields
                        .Select(field => new SelectListItem
                        {
                            Value = field,
                            Text = f.FirstOrDefault(x => x.RD_FildName == field)
                                       ?.RD_FildNameFa ?? field
                        })
                        .ToList();
                    ReportViewModel rv = new ReportViewModel
                    {
                        RS1_ID = r.RS1_ID,
                        RD_TBNameFa = r.RD_TBNameFa ?? "",
                        RS1_Const = r.RS1_Const ?? "",
                        RS1_Name = r.RS1_Name ?? "",
                        RS1_Desc = r.RS1_Desc ?? "",
                        RD_TBName = r.RD_TBName ?? ""
                    };

                    return View(rv);
                }

                ViewBag.valid = "موردی وجود ندارد";
                return View();
            }

            ViewBag.valid = "شما مجوز دسترسی ندارید";
            return View();
        }
