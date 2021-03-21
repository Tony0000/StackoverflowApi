using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Jobs.Queries.GetJobsList
{
    public class GetJobsListQueryHandler : IRequestHandler<GetJobsListQuery, JobListVm>
    {
        private readonly IOverflowDbContext _context;
        private readonly IMapper _mapper;

        public GetJobsListQueryHandler(IOverflowDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<JobListVm> Handle(GetJobsListQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _context.Jobs
                .ProjectTo<JobDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new JobListVm
            {
                Jobs = jobs,
                Count = jobs.Count
            };
            
            return vm;
        }
    }
}