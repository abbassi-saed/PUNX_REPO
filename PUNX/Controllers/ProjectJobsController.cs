using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PUNX.Domain.DTOs;
using PUNX.Domain.Repository;
using System.Collections.Generic;


namespace PUNX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectJobsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectJobsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{projectId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectJobDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetProjectJobs(int projectId)
        {

            var projectJobsFromRepo = _unitOfWork.Job.GetJobsByProjectId(projectId);
            if (projectJobsFromRepo == null)
            {
                return NotFound();
            }
            var projecstDtos = _mapper.Map<IEnumerable<ProjectJobDto>>(projectJobsFromRepo);
            return Ok(projecstDtos);
        }
    }
}
