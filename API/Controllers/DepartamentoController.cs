using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    public class DepartamentoController : BaseController
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        public DepartamentoController( IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _UnitOfWork = UnitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Departamento>>> Get(){
            var departamento = await _UnitOfWork.Departamento.GetAllAsync();
            return Ok(departamento);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<Departamento>>> GetId(int id){
            var departamento = await _UnitOfWork.Departamento.GetByIdAsync(id);
            if (departamento == null){
                return NotFound();
            }
            return Ok(departamento);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Departamento>> Post(DepartamentoDto departamentoDto){
            var departamento = _mapper.Map<Departamento>(departamentoDto);
            this._UnitOfWork.Departamento.Add(departamento);
            await _UnitOfWork.SaveAsync();
            if(departamento == null){
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = departamento.Id}, departamentoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Departamento>> Put(int id, [FromBody] Departamento departamento){
            if (departamento.Id == 0){
                departamento.Id = id;
            }
            if (departamento.Id != id){
                return BadRequest();
            }
            if (departamento == null){
                return NotFound();
            }
            _UnitOfWork.Departamento.Update(departamento);
            await _UnitOfWork.SaveAsync();
            return Ok(departamento);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id){
            var departamento = await _UnitOfWork.Departamento.GetByIdAsync(id);
            if (departamento == null){
                return NotFound();
            }
            _UnitOfWork.Departamento.Remove(departamento);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
