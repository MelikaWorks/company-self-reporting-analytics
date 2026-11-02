// Selected GET action from Controllers/CustomerPageController.cs.
// Builds the withdrawal selection for published documents belonging to the active page customer.
// This excerpt does not include or certify the legacy POST mutation action.
public IActionResult UnPublishDocument(int? id)
{
    if (HttpContext.Session.GetString("Admin_Email") == null)
        return RedirectToAction("splogin", "Account");

    string email = HttpContext.Session.GetString("Admin_Email")!;
    var qemail = _db.Admin_tbs.SingleOrDefault(a => a.Admin_Email == email);

    if (qemail == null)
    {
        return RedirectToAction("splogin", "Account");
    }
    else
    {
        if (qemail.Role_Id == 1 || qemail.Admin_AccessCustomer == true)
        {
            if (id != null)
            {
                if (id > 0)
                {
                    CustomerPage_tb page = new CustomerPage_tb();
                    HttpContext.Session.SetInt32("idcust", (int)(page.Cust_ID ?? 0L));

                    var i = _db.CustomerPage_tbs.FirstOrDefault(a => a.CustPage_ID == id);
                    if (i == null)
                    {
                        ViewBag.valid = "موردی یافت نشد";
                        return View();
                    }

                    HttpContext.Session.SetInt32("idp", id.Value);
                    HttpContext.Session.SetInt32("idc", (int)(i.Cust_ID ?? 0L));

                    var ss = from m in _db.CustomerDoc_tbs
                             join e1 in _db.St_Document_tbs on m.Doc_ID equals e1.Doc_ID
                             where m.Cust_ID == i.Cust_ID && m.CustDoc_Pub == true
                             select new
                             {
                                 e1.Doc_Title,
                                 m.Doc_ID,
                                 m.CustDoc_Pub
                             };

                    ViewBag.ss = new SelectList(ss.ToList(), "Doc_ID", "Doc_Title");
                    return View();
                }
                else
                {
                    ViewBag.valid = "شماره کاربر منتقل نشده است لطفا مجدداً وارد این صفحه شوید / سشن منقضی شده است";
                    return View();
                }
            }
            else
            {
                return RedirectToAction("splogin", "Account");
            }
        }
        else
        {
            ViewBag.valid = "شما مجوز دسترسی ندارید";
            return View();
        }
    }
}

