using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        public ClienteController( IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _UnitOfWork = UnitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get(){
            var cliente = await _UnitOfWork.Cliente.GetAllAsync();
            return Ok(cliente);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetId(int id){
            var cliente = await _UnitOfWork.Cliente.GetByIdAsync(id);
            return Ok(cliente);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cliente>> Post(ClienteDto clienteDto){
            var cliente = _mapper.Map<Cliente>(clienteDto);
            this._UnitOfWork.Cliente.Add(cliente);
            await _UnitOfWork.SaveAsync();
            if(cliente == null){
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = cliente.Id}, cliente);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Cliente>> Put(int id, [FromBody] Cliente cliente)
        {
            var clienteId = await _UnitOfWork.Cliente.GetByIdAsync(id);
            if (clienteId == null)
            {
                return NotFound();
            }
            _UnitOfWork.Cliente.Update(cliente);
            await _UnitOfWork.SaveAsync();
            return Ok(cliente);
        }
    }
}