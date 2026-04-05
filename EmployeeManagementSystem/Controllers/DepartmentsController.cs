using Microsoft.AspNetCore.Mvc;

public class DepartmentsController : Controller
{
    public IActionResult Department()
    {
        return View(); // This will open Department.cshtml
    }
}