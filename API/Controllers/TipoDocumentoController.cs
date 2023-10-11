using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TipoDocumentoController : BaseController
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        public TipoDocumentoController(IUnitOfWork unitOfWork, IMapper mapper){
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoDocumento>>> Get(){
            var nameVar = await _UnitOfWork.TipoDocumento.GetAllAsync();
            return Ok(nameVar);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TipoDocumento>>> Get(int id){
            var tipoDocumento = await _UnitOfWork.TipoDocumento.GetByIdAsync(id);
            return Ok(tipoDocumento); 
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoDocumento>> Post(TipoDocumento tipoDocumento){
            this._UnitOfWork.TipoDocumento.Add(tipoDocumento);
            await _UnitOfWork.SaveAsync();
            if (tipoDocumento==null){
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = tipoDocumento.Id }, tipoDocumento);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoDocumento>> Put(int id, TipoDocumento tipoDocumento){
            tipoDocumento.Id = id;
            _UnitOfWork.TipoDocumento.Update(tipoDocumento);
            await _UnitOfWork.SaveAsync();
            return Ok(tipoDocumento);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoDocumento>> Delete(int id){
            var tipoDocumento = await _UnitOfWork.TipoDocumento.GetByIdAsync(id);
            if (tipoDocumento == null){
                return BadRequest();
            }
            _UnitOfWork.TipoDocumento.Remove(tipoDocumento);
            await _UnitOfWork.SaveAsync();
            return Ok(tipoDocumento);
        }
    }
}