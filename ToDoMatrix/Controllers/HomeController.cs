using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
/*using System.Linq; This will be used for the db*/
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
/*using ToDoMatrix.Models; this will import models */

namespace ToDoMatrix.Controllers
{
    public class HomeController : Controller
    {
/*        // This is setting up the db to a variable
        private ToDoContext todoContext { get; set; }
        public HomeController(ToDoContext tdx)
        {
            todoContext = tdx;
        }
*/

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Task()
        {
            return View(); //"Task"
        }

        // This is going to post the to do list to the db and possibly
        // return a confirmation page. It will do all of this if the 
        // models are valid. If it's not it will return the view

/*        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                todoContext.Add(ar);
                todoContext.SaveChanges();

                return View("Confirmation", ar);
            }
            else
            {
                ViewBag.Categories = todoContext.Categories.ToList();

                return View();
            }

        }


        // This will be getting at the todos are returning them to a list
        // in the view
        [HttpGet]
        public IActionResult WaitList()
        {
            var applications = todoContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(applications);

        }

        // This is going to get the correct todo when edit
        // button is hit
        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Categories = todoContext.Categories.ToList();

            var application = todoContext.Responses.FirstOrDefault(x => x.ApplicationId == applicationid);

            return View("ToDForm", application);
        }


        // this is going to post the changes made to the todo
        [HttpPost]
        public IActionResult Edit(ApplicationResponse ar)
        {
            todoContext.Update(ar);
            todoContext.SaveChanges();

            return RedirectToAction("TodoHome");
        }


        // This will find the todo in the db to delete
        [HttpGet]
        public IActionResult Delete(int applicationid)
        {
            var application = todoContext.Responses.Single(x => x.ApplicationId == applicationid);

            return View(application);
        }

        // this will actually delete the db
        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            todoContext.Responses.Remove(ar);
            todoContext.SaveChanges();

            return RedirectToAction("TodoHome");
        }*/


    }

}
