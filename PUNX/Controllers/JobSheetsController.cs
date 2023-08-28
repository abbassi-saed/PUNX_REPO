using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PUNX.Domain.DTOs;
using PUNX.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUNX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSheetsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobSheetsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("{projectId}/{jobId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobSheetDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetJobSheetsAsync(int projectId, int jobId)
        {

            var jobSheetsFromRepo = await _unitOfWork.Sheet.GetSheetsByProjectAndJobId(projectId, jobId);
            if (jobSheetsFromRepo == null)
            {
                return NotFound();
            }
            var jobSheetsDto = _mapper.Map<IEnumerable<JobSheetDto>>(jobSheetsFromRepo);
            return Ok(jobSheetsDto);
        }

        [HttpGet("{projectId}/{jobId}/{sheetId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobSheetDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetJobSheetAsync(int projectId, int jobId, int sheetId)
        {

            var jobSheetsFromRepo = await _unitOfWork.Sheet.GetSheetsBySheetIdAndProjectAndJobId(projectId, jobId, sheetId);
            if (jobSheetsFromRepo == null)
            {
                return NotFound();
            }
            var jobSheetsDto = _mapper.Map<IEnumerable<JobSheetDto>>(jobSheetsFromRepo);
            return Ok(jobSheetsDto);
        }
    }
}
