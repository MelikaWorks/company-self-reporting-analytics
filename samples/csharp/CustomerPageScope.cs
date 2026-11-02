// Complete CPage action excerpt. Surrounding controller and dependencies omitted.
// Legacy name-presence check; not comprehensive profile validation or global authorization.
public IActionResult CPage()
{
    if (HttpContext.Session.GetString("Cust_Email") == null)
        return RedirectToAction("CLogin", "Account");

    string email = HttpContext.Session.GetString("Cust_Email")!;
    var qemail = _db.Customer_tbs.SingleOrDefault(a => a.Cust_Email == email);

    if (qemail == null)
    {
        return RedirectToAction("CLogin", "Account");
    }
    else
    {
        if (qemail.Role_Id == 3)
        {
            if (qemail.Cust_Name != null)
            {
                var qlist = _db.CustomerPage_tbs
                    .Where(a => a.Cust_ID == qemail.Cust_ID)
                    .OrderBy(a => a.CustPage_ID)
                    .ToList();

                if (qlist.Count == 0)
                {
                    ViewBag.Message = "موردی وارد نشده است!";
                    return View();
                }
                else
                {
                    ViewBag.Message = TempData["OK"];
                    ViewBag.State = TempData["Result"];
                    return View(qlist);
                }
            }
            else
            {
                ViewBag.valid = "ابتدا پروفایل خود را تکمیل نمایید!";
                return View();
            }
        }
        else
        {
            ViewBag.valid = "شما دسترسی ندارید!";
            return View();
        }
    }
}

