using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practical_11.Models;
using Practical_11.Services.Interfaces;
using Practical_11.Services.RepositoryClass;
using System.Security.Cryptography;

namespace Practical_11.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        public ProductController(IProduct product)
        {
            this._product = product;
        }
        // GET: ProductController
        public IActionResult Index()
        {
            var requestId = GetRequestId();
            try
            {
                ViewBag.File = "List of products";
                return PartialView("_GetAllProducts", _product.GetProducts());
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

        // GET: ProductController/Details/5
        public IActionResult Details(int id)
        {
            var requestId = GetRequestId();            
            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.File = "Detail of product";
                    var product = _product.GetSingleProduct(id);                    
                    if (product == null)
                    {
                        return NotFound();
                    }
                    return PartialView("_Details", product);
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
            return RedirectToAction("Index");
        }

        // GET: ProductController/Create
        public IActionResult Create()
        {
            ViewBag.File = "Detail of product";
            return PartialView("_Create");
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            var requestId = GetRequestId();
            if (ModelState.IsValid)
            {
                try
                {
                    product.Id = _product.GetProductsCount() + 1;
                    _product.AddOrUpdateProduct(product.Id, product);
                    return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var requestId = GetRequestId();
            try
            {
                ViewBag.File = "Edit product";
                var product = _product.GetSingleProduct(id);                
                if (product == null)
                {
                    return NotFound();
                }
                return PartialView("_Edit", product);
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

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product productData)
        {
            var requestId = GetRequestId();
            if (ModelState.IsValid)
            {
                try
                {
                    _product.AddOrUpdateProduct(id, productData);
                    return RedirectToAction("Index");
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

        public ActionResult Delete(int id)
        {
            var requestId = GetRequestId();
            try
            {
                _product.RemoveProduct(id);
                return RedirectToAction("Index");
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
