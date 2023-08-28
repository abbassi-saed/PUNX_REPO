using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PUNX.DataAccess.Implementation;
using PUNX.Domain.DTOs;
using PUNX.Domain.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace PUNX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartDataController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChartDataController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetChartDataAsync()
        {
            var labels = new[] { "Users", "Jobs", "Sheets" };

            var userCollection = await _unitOfWork.User.GetAllAsync();
            var userCounts = userCollection.ToList().Count;

            var jobsCollection = await _unitOfWork.Job.GetAllAsync();
            var jobCounts = jobsCollection.ToList().Count;

            var sheetCollection = await _unitOfWork.Sheet.GetAllAsync();
            var sheetCounts = sheetCollection.ToList().Count;

            var data = new[] { userCounts, jobCounts, sheetCounts };
            var backgroundColor = new[] { "#FF6384", "#36A2EB", "#FFCE56" };

            var chartData = new
            {
                Labels = labels,
                Data = data,
                BackgroundColor = backgroundColor
            };

            return Ok(chartData);
        }


        [HttpGet("GetProjectByUserType")]
        public async Task<IActionResult> GetCountOfProjectsByUserType()
        {
            var projectCounts = await _unitOfWork.Project.GetProjectCountByUserType();

            return Ok(projectCounts);

        }


    }
}
