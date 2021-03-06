﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MrFixIt.Controllers
{
    public class JobsController : Controller
    {
        private MrFixItContext db = new MrFixItContext();

        //returns list of all jobs on index page
        public IActionResult Index()
        {
            return View(db.Jobs.Include(i => i.Worker).ToList());
        }

        //returns create view
        public IActionResult Create()
        {
            return View();
        }

        //Adds job to db
        [HttpPost]
        public IActionResult Create(Job job)
        {
            db.Jobs.Add(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Claim action takes JobID input, returns that job on claim page
        public IActionResult Claim(int id)
        {
            var thisJob = db.Jobs.FirstOrDefault(items => items.JobId == id);
            return View(thisJob);
        }

        //adds worker to local job object, saves changes to db
        [HttpPost]
        public IActionResult Claim(int id, string title)
        {
            Job thisJob = db.Jobs.FirstOrDefault(j => j.JobId == id);
            thisJob.Worker = db.Workers.FirstOrDefault(i => i.UserName == User.Identity.Name);
            db.Entry(thisJob).State = EntityState.Modified;
            db.SaveChanges();
            return Content("");
        }

        //Update IsPending value
        [HttpPost]
        public IActionResult SetPendingTrue(int JobId)
        {
            var thisJob = db.Jobs.FirstOrDefault(j => j.JobId == JobId);
            thisJob.IsPending = true;
            db.Entry(thisJob).State = EntityState.Modified;
            db.SaveChanges();
            return Json(thisJob);
        }

        //Updates IsCompleted value
        [HttpPost]
        public IActionResult SetCompleteTrue(int JobId)
        {
            var thisJob = db.Jobs.FirstOrDefault(j => j.JobId == JobId);
            thisJob.IsCompleted = true;
            db.Entry(thisJob).State = EntityState.Modified;
            db.SaveChanges();
            return Json(thisJob);
        }
    }
}
