using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using storeapp.Models;
using BLL;
using BOL;
using DAL;
namespace storeapp.Controllers;

public class DepartmentController : Controller
{
    private readonly ILogger<DepartmentController> _logger;

    public DepartmentController(ILogger<DepartmentController> logger)
    {
        _logger = logger;
    }
[HttpGet]
    public IActionResult Index()
    {  HRManager hrmgr=new HRManager();
       List<Department> departments=hrmgr.GetAllDepartments();
        ViewData["departments"]=departments;
        return View();
    }
    [HttpGet]
    public IActionResult Insert()
    {
        Department dep=new Department();
        return View(dep);
    }
    [HttpPost]
    public IActionResult Insert(int id, string name, string location)
    {
     HRManager mgr=new HRManager();
       
        if(mgr.Insert(id, name, location)){
            return RedirectToAction("Index");
        }
    return View();
    }
    public IActionResult Delete(int id)
    {  
         HRManager hg=new HRManager();
        hg.Deletedep(id);
            return RedirectToAction("Index");
        
    }
    [HttpGet]
     public IActionResult Update()
     {
        return View();
     }
     [HttpPost]
    public IActionResult Update(int id, string name, string location)
    {
     HRManager mgr=new HRManager();
       
     mgr.Updatedep(id, name, location);
    
    return RedirectToAction("Index");
    
    
}
   
}
