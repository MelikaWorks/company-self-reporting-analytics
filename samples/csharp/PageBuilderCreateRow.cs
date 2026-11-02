// Selected Page Builder excerpt from the migration milestone.
// Host controller, entity classes and supporting views are intentionally omitted.

// Helpers used by the selected create-row action.
private Admin_tb? GetCurrentAdmin()
        {
            var email = HttpContext.Session.GetString("Admin_Email");
            if (string.IsNullOrWhiteSpace(email))
                return null;

            return _db.Admin_tbs.SingleOrDefault(a => a.Admin_Email == email);
        }

private bool HasPageBuilderAccess(Admin_tb? admin)
        {
            return admin != null && (admin.Role_Id == 1 || admin.Admin_AccessPage == true);
        }

private long? GetCurrentPageIdFromSession()
        {
            return long.TryParse(HttpContext.Session.GetString("idp"), out var idp) ? idp : null;
        }

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult CreatPage(PageBuildCustViewModel v)
        {
            var admin = GetCurrentAdmin();
            if (admin == null)
                return RedirectToAction("splogin", "Account");

            if (!HasPageBuilderAccess(admin))
            {
                ViewBag.valid = "شما دسترسی ندارید!";
                return View(v);
            }

            LoadColumnSelectList(v.Col_ID);

            if (!ModelState.IsValid)
                return View(v);

            var idp = GetCurrentPageIdFromSession();
            if (idp == null || idp <= 0)
            {
                ModelState.AddModelError("", "شناسه صفحه در Session یافت نشد.");
                return View(v);
            }

            var customerPage = _db.CustomerPage_tbs.FirstOrDefault(a => a.CustPage_ID == idp.Value);
            if (customerPage == null)
            {
                ModelState.AddModelError("", "صفحه مشتری یافت نشد.");
                return View(v);
            }

            var entity = new PageBuilderCust_tb
            {
                PagBC_IDJoint = "1",
                PagBC_Row = v.PagBC_Row,
                Col_ID = v.Col_ID,
                CustPage_ID = idp.Value,
                Cust_ID = customerPage.Cust_ID,
                Admin_ID = admin.Admin_ID
            };

            ApplyColumnContent(entity, v);

            _db.PageBuilderCust_tbs.Add(entity);
            _db.SaveChanges();

            TempData["Pub"] = "موارد با موفقیت ثبت شد";
            return RedirectToAction("CreatPage", new { id = idp.Value });
        }
