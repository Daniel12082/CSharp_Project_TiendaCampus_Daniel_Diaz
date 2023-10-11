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
    public class CitaController : BaseController
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        public CitaController(IUnitOfWork unitOfWork, IMapper mapper){
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Cita>>> Get(){
            var nameVar = await _UnitOfWork.Cita.GetAllAsync();
            return Ok(nameVar);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Cita>>> Get(int id){
            var cita = await _UnitOfWork.Cita.GetByIdAsync(id);
            return Ok(cita); 
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Cita>> Post(CitaDto citaDto){
            var cita = _mapper.Map<Cita>(citaDto);
            this._UnitOfWork.Cita.Add(cita);
            await _UnitOfWork.SaveAsync();
            if (cita==null){
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = cita.Id }, cita);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Cita>> Put(int id, CitaDto citaDto){
            var cita = _mapper.Map<Cita>(citaDto);
            cita.Id = id;
            _UnitOfWork.Cita.Update(cita);
            await _UnitOfWork.SaveAsync();
            return Ok(cita);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cita>> Delete(int id){
            var cita = await _UnitOfWork.Cita.GetByIdAsync(id);
            if (cita == null){
                return BadRequest();
            }
            _UnitOfWork.Cita.Remove(cita);
            await _UnitOfWork.SaveAsync();
            return Ok(cita);
        }
    }
}