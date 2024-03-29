﻿using BlazorCrud.Server.Models;
using BlazorCrud.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly DbcrudBlazorContext _dbcontext;

        public DepartamentoController(DbcrudBlazorContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<DepartamentoDTO>>();
            var listaDepartamaentoDTO= new List<DepartamentoDTO>();

            try
            {
                foreach (var item in await _dbcontext.Departamentos.ToListAsync())
                {
                    listaDepartamaentoDTO.Add(new DepartamentoDTO
                    {
                        IdDepartamento = item.IdDepartamento,
                        Nombre = item.Nombre,
                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaDepartamaentoDTO;

            }catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje=ex.Message;
            }

            return Ok(responseApi);
        }
    }
}
