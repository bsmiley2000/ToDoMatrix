using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
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


        public IActionResult Index()
        {
            var taskList = matrixApplicationContext.Responses.ToList();
            return View(taskList);
        }
        /*        public IActionResult Task()
                {
                    return View(); //"Task"
                }*/

        // This is going to post the to do list to the db and possibly
        // return a confirmation page. It will do all of this if the 
        // models are valid. If it's not it will return the view

        [HttpGet]
        public IActionResult Task()
                                                   {
            ViewBag.Categories = matrixApplicationContext.Categories.ToList();
            TaskModel model = new TaskModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Task(TaskModel tm)
        {
            if (ModelState.IsValid)
            {
                matrixApplicationContext.Add(tm);
                matrixApplicationContext.SaveChanges();

                return View("Confirmation", tm);
            }
            else
            {
                ViewBag.Categories = matrixApplicationContext.Categories.ToList();

                return View(tm);
            }

        }


        // This is going to get the correct todo when edit
        // button is hit
        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = matrixApplicationContext.Categories.ToList();

            var application = matrixApplicationContext.Responses.FirstOrDefault(x => x.TaskId == taskid);

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
        public IActionResult Delete(int taskid)
        {
            var application = matrixApplicationContext.Responses.Single(x => x.TaskId == taskid);

            return View(application);
        }

        // this will actually delete the db
        [HttpPost]
        public IActionResult Delete(TaskModel tm)
        {
            matrixApplicationContext.Responses.Remove(tm);
            matrixApplicationContext.SaveChanges();

            return RedirectToAction("Index");
        }


    }

}
