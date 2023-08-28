using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PUNX.Domain.DTOs;
using PUNX.Domain.Repository;
using System;
using System.Threading.Tasks;

namespace PUNX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CircleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCircleProperties(int id)
        {
            // get Radius from database.
            var circle = await _unitOfWork.Circle.GetByIdAsync(id);

            if (circle == null)
            {
                return NotFound(); // Return 404 if the circle is not found.
            }

            double radius = circle.Radius; 
            double area = Math.PI * radius * radius;
            double circumference = 2 * Math.PI * radius;
            double diameter = 2 * radius;


            return Ok(new CircleProperties(radius, area, circumference, diameter));
        }
    }
}
