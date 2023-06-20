using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practical_11.Data;
using Practical_11.Models;
using Practical_11.Services.Interfaces;
using Practical_11.Services.RepositoryClass;
using System.Net.NetworkInformation;

namespace Practical_11.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeService;
        public EmployeeController(IEmployee empService)
        {
            _employeeService = empService;
        }
        // GET: EmployeeController
        public IActionResult Index()
        {
            var requestId = GetRequestId();
            try
            {
                var data = _employeeService.GetEmployees();
                return View(data);
            }
            catch (Exception ex)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = requestId,
                    ErrorMessage = "An error occurred: " + ex.Message,
                    ErrorCode = 500
            };
                return View("Error", errorViewModel);
            }
        }

        // GET: EmployeeController/Create
        public IActionResult Create()
        {
            var empId = _employeeService.GetEmployeesCount();
            ViewBag.EmployeeId = empId;
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            var requestId = GetRequestId();
            if (ModelState.IsValid)
            {
                try
                {
                    _employeeService.AddOrUpdateEmployee(employee.Id, employee);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    var errorViewModel = new ErrorViewModel
                    {
                        RequestId = requestId,
                        ErrorMessage = "An error occurred: " + ex.Message,
                        ErrorCode = 500
                    };
                    return View("Error", errorViewModel);
                }
            }
            return View();
        }

        // GET: EmployeeController/Details/5
        public IActionResult Details(int id)
        {
            var requestId = GetRequestId();
            if (ModelState.IsValid)
            {
                try
                {
                    var employee = _employeeService.GetSingleEmployee(id);
                    if (employee == null)
                    {
                        return NotFound();
                    }
                    return View(employee);
                }
                catch (Exception ex)
                {
                    var errorViewModel = new ErrorViewModel
                    {
                        RequestId = requestId,
                        ErrorMessage = "An error occurred: " + ex.Message,
                        ErrorCode = 500
                    };
                    return View("Error", errorViewModel);
                }
            }
            return View("Index");
        }

        // GET: EmployeeController/Edit/5
        public IActionResult Edit(int id)
        {
            var requestId = GetRequestId();
            try
            {
                var employee = _employeeService.GetSingleEmployee(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = requestId,
                    ErrorMessage = "An error occurred: " + ex.Message,
                    ErrorCode = 500
                };
                return View("Error", errorViewModel);
            }
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employeeData)
        {
            var requestId = GetRequestId();
            if (ModelState.IsValid)
            {
                try
                {
                    _employeeService.AddOrUpdateEmployee(id, employeeData);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    var errorViewModel = new ErrorViewModel
                    {
                        RequestId = requestId,
                        ErrorMessage = "An error occurred: " + ex.Message,
                        ErrorCode = 500
                    };
                    return View("Error", errorViewModel);
                }
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var requestId = GetRequestId();
            try
            {
                _employeeService.RemoveEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = requestId,
                    ErrorMessage = "An error occurred: " + ex.Message,
                    ErrorCode = 500
                };
                return View("Error", errorViewModel);
            }
        }
        public string GetRequestId()
        {
            return HttpContext.TraceIdentifier;
        }
    }
}
