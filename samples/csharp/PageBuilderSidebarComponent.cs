// Selected method from TableListSideViewComponent.
// The host ViewComponent and injected ParsianDbContext are omitted.

public IViewComponentResult Invoke()
        {
            var qlist = _db.DBTableName_tbs
                .Where(a => a.Table_UseCust == true)
                .OrderBy(a => a.Table_ID)
                .ToList();

            ViewBag.Message = qlist.Any() ? null : "موردی وارد نشده است!";
            return View("~/Views/PageBuilder/P_TableListSide.cshtml",qlist);
        }
