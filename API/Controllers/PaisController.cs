using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class PaisController : BaseController
{
    private readonly UnitOfWork _unitOfwork;

    public PaisController(UnitOfWork _UnitOfwork)
    {
        _unitOfwork = _UnitOfwork;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Pais>>> Get()
    {
        var paises = await _unitOfwork.Paises.GetAllAsync();
        return Ok(paises);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pais>> Get(int id)
    {
        var pais = await _unitOfwork.Paises.GetByIdAsync(id);
        if (pais == null)
        {
            return NotFound();
        }
        return pais;
    }
}
