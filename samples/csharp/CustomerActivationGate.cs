// Selected excerpt from Controllers/AccountController.cs, inside CLogin after credential lookup.
// Shows active-account and customer-role checks only; authentication setup is omitted.
if (user.Cust_IsActive != true)
{
    await _audit.LogAsync("LOGIN_FAIL", actor: user.Cust_Email, message: "Customer not active.");
    ModelState.AddModelError("Cust_Email", "حساب کاربری شما فعال نشده است.");
    return View(model);
}

if (user.Role_Id != 3)
{
    await _audit.LogAsync("LOGIN_FAIL", actor: user.Cust_Email, message: "Customer role not allowed.");
    ModelState.AddModelError("", "ایمیل یا رمز عبور اشتباه است.");
    return View(model);
}

