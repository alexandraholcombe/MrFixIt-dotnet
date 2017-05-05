using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MrFixIt.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //Job marked complete by worker
        public bool IsCompleted { get; set; }

        //Job actively being worked on
        public bool IsPending { get; set; }

        //Worker who has claimed job
        public virtual Worker Worker { get; set; }

        //Find worker by username
        public Worker FindWorker(string UserName)
        {
            Worker thisWorker = new MrFixItContext().Workers.FirstOrDefault(i => i.UserName == UserName);
            return thisWorker;
        }
    }
}