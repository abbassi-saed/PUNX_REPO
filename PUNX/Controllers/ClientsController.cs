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
    public class ClientsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ClientDto>))]
        public async Task<IActionResult> GetAllClients()
        {
            var clientsFromRepo = await _unitOfWork.Client.GetAllAsync();
            var clientstDto = _mapper.Map<IEnumerable<ClientDto>>(clientsFromRepo);
            return Ok(clientstDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetClientById(int id)
        {
            var clientFromRepo = await _unitOfWork.Client.GetByIdAsync(id);
            if (clientFromRepo == null)
            {
                return NotFound();
            }

            var clientDto = _mapper.Map<ClientDto>(clientFromRepo);
            return Ok(clientDto);
        }
    }
}
