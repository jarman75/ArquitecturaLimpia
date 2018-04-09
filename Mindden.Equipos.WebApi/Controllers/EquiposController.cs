using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mindden.Equipos.WebApi.Models;
using Mindden.Equipos.Application.Interfaces;
using Mindden.Equipos.Application.DataService;
using Mindden.Equipos.Application.Responses;

namespace Mindden.Equipos.WebApi.Controllers
{
    [Route("api/[controller]")]    
    public class EquiposController : Controller
    {
        private readonly IEquipoService _equipoService;
        
        public EquiposController (IEquipoService equipoService)
        {
            _equipoService = equipoService;
        }

        
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ObtenerEquipoResponse response =  _equipoService.ObtenerEquipo(id);
            if (response.Status == StatusEnum.CorrectOperation)
            {
                return Ok(DtoEquipo.FromItem(response.Equipo));
            }else
            {
                return NotFound();
            }
            
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] DtoEquipo item)
        {
            
            DSEquipo ds = item.ToItem();
            CrearEquipoResponse response = _equipoService.CrearEquipo(ds);
            if (response.Status == StatusEnum.CorrectOperation)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DtoEquipo item)
        {
            item.Id = id;
            DSEquipo ds = item.ToItem();
            ActualizarEquipoResponse response = _equipoService.ActualizarEquipo(ds);
            if (response.Status == StatusEnum.CorrectOperation)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NotFound();
        }
    }
}
