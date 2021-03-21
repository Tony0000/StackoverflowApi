using System.Collections.Generic;

namespace Application.Jobs.Queries.GetJobsList
{
    public class JobListVm
    {
        public IList<JobDto> Jobs { get; set; }
        
        public int Count { get; set; }
    }
}