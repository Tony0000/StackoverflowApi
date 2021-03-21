using Domain.Models;
using Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Api{ 
    public class DataSeeder
    {
        public static void Initialize(OverflowDbContext context)
        {
            if(!context.Jobs.Any())
            {
                var jobs = new List<Job>
                {
                    new Job{ Title = "Vaga 01", Description = "Description 01", Tags = "java, spring", Url = "stackoverflow.com/jobs/1" },
                    new Job{ Title = "Vaga 02", Description = "Description 02", Tags = "c++", Url = "stackoverflow.com/jobs/2" },
                    new Job{ Title = "Vaga 03", Description = "Description 03", Tags = "python", Url = "stackoverflow.com/jobs/3" },
                };
                context.Jobs.AddRange(jobs);
                context.SaveChanges();
            }
        }
    }
}