using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Models;

namespace Application.Jobs.Queries.GetJobsList
{
    public class JobDto : IMapFrom<Job>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Tags { get; set; }
        public DateTime Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Job, JobDto>();
        }
    }
}