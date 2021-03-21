using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Jobs.Commands.UpsertJob
{
    public class UpsertCategoryCommand : IRequest<bool>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Tags { get; set; }
        public DateTime Date { get; set; }

        public class UpsertCategoryCommandHandler : IRequestHandler<UpsertCategoryCommand, bool>
        {
            private IOverflowDbContext _context;
            public UpsertCategoryCommandHandler(IOverflowDbContext context)
            {
                _context = context;
            }
            
            public async Task<bool> Handle(UpsertCategoryCommand request, CancellationToken cancellationToken)
            {
                var entity = new Job
                {
                    Title = request.Title,
                    Description = request.Description,
                    Url = request.Url,
                    Tags = request.Tags,
                    Date = request.Date
                };
                try
                {
                    _context.Jobs.Add(entity);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                catch (Exception e)
                {
                    return false;
                }

                return true;
            }
        }
    }
}