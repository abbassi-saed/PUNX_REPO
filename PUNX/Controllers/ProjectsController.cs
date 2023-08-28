using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PUNX.Domain.Repository;
using PUNX.Domain.DTOs;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUNX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProjectDto>))]
        public async Task<IActionResult> GetAllProjectsAsync()
        {
            var projectsFromRepo = await _unitOfWork.Project.GetAllAsync();
            var projecstDtos = _mapper.Map<IEnumerable<ProjectDto>>(projectsFromRepo);
            return Ok(projecstDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var projectFromRepo = await _unitOfWork.Project.GetByIdAsync(id);
            if (projectFromRepo == null)
            {
                return NotFound();
            }

            var projectDto = _mapper.Map<ProjectDto>(projectFromRepo);
            return Ok(projectDto);
        }
    }
}
