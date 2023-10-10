using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MascotaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MascotaController (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MascotaDto>>>Get()
        {
            var mascotas = await _unitOfWork.Mascota.GetAllAsync();
            return _mapper.Map<List<MascotaDto>>(mascotas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MascotaDto>>Get(int id)
        {
            var mascota = await _unitOfWork.Mascota.GetByIdAsync(id);
            if(mascota == null)
            {
                return NotFound();
            }
            return _mapper.Map<MascotaDto>(mascota);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MascotaDto>>Post(MascotaDto mascotaDto)
        {
            var mascota = _mapper.Map<Mascota>(mascotaDto);

            if (mascotaDto.FechaNacimiento == DateTime.MinValue)
            {
                mascotaDto.FechaNacimiento = DateTime.Now; 
            }
            this._unitOfWork.Mascota.Add(mascota);
            await _unitOfWork.SaveAsync();
            
            if(mascota == null)
            {
                return BadRequest();
            }
            mascotaDto.Id = mascota.Id;
            return CreatedAtAction(nameof(Post), new {id = mascotaDto.Id}, mascotaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MascotaDto>> Put(int id, [FromBody] MascotaDto mascotaDto)
        {
            if(mascotaDto == null)
            {
                return NotFound();
            }
            var mascotas = _mapper.Map<Mascota>(mascotaDto);
            _unitOfWork.Mascota.Update(mascotas);
            await _unitOfWork.SaveAsync();
            return mascotaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var mascota = await _unitOfWork.Mascota.GetByIdAsync(id);
            if(mascota == null)
            {
                return NotFound();
            }
            _unitOfWork.Mascota.Remove(mascota);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}