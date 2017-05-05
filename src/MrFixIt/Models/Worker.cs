using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace MrFixIt.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Is worker available? (not in use)
        //Worker should only be able to work on one job at a time
        public bool IsAvailable { get; set; }

        //this comes from Identity.User
        public string UserName { get; set; }

        //list of jobs associated with worker
        public virtual ICollection<Job> Jobs { get; set; }

        public Worker()
        {
            IsAvailable = true;
        }

    }
}