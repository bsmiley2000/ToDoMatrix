using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
/*using System.Linq; This will be used for the db*/
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ToDoMatrix.Models;

namespace ToDoMatrix.Controllers
{
    public class HomeController : Controller
    {
        // This is setting up the db to a variable
        private MatrixApplicationContext matrixApplicationContext { get; set; }
        public HomeController(MatrixApplicationContext x)
        {
            matrixApplicationContext = x;
        }


/*        public IActionResult Index()
        {
            return View();
        }*/
        public IActionResult Task()
        {
            return View(); //"Task"
        }

        // This is going to post the to do list to the db and possibly
        // return a confirmation page. It will do all of this if the 
        // models are valid. If it's not it will return the view

        [HttpPost]
        public IActionResult Task(TaskModel tm)
        {
            if (ModelState.IsValid)
            {
                matrixApplicationContext.Add(tm);
                matrixApplicationContext.SaveChanges();

                return View("Index", tm);
            }
            else
            {
                ViewBag.Categories = matrixApplicationContext.Categories.ToList();

                return View();
            }

        }


        // This will be getting at the todos are returning them to a list
        // in the view
        [HttpGet]
        public IActionResult Index()
        {
            var applications = matrixApplicationContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Task)
                .ToList();

            return View(applications);

        }

        // This is going to get the correct todo when edit
        // button is hit
        [HttpGet]
        public IActionResult Edit(int categoryid)
        {
            ViewBag.Categories = matrixApplicationContext.Categories.ToList();

            var application = matrixApplicationContext.Responses.FirstOrDefault(x => x.CategoryId == categoryid);

            return View("Task", application);
        }


        // this is going to post the changes made to the todo
        [HttpPost]
        public IActionResult Edit(TaskModel tm)
        {
            matrixApplicationContext.Update(tm);
            matrixApplicationContext.SaveChanges();

            return RedirectToAction("Index");
        }


        // This will find the todo in the db to delete
        [HttpGet]
        public IActionResult Delete(int categoryid)
        {
            var application = matrixApplicationContext.Responses.Single(x => x.CategoryId == categoryid);

            return View(application);
        }

        // this will actually delete the db
        [HttpPost]
        public IActionResult Delete(TaskModel tm)
        {
            matrixApplicationContext.Responses.Remove(tm);
            matrixApplicationContext.SaveChanges();

            return RedirectToAction("TodoHome");
        }


    }

}
