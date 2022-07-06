using ApiCnt.data.repositorios;
using ApiCnt.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCnt.Controllers
{
    [Route("api/pacientes")]
    [ApiController]
    public class pacientesController : ControllerBase
    {
        private readonly Ipacientes _pacienteRepo;

        public pacientesController(Ipacientes pacienteRepo)
        {
            _pacienteRepo = pacienteRepo;
        }

        [HttpGet("{parametro}")]
        public async Task<IActionResult> TraerPacientes(string parametro)
        {
            return Ok(await _pacienteRepo.GetallPacientes(parametro));
        }


        [Route("fumador")]
        [HttpGet]
        public async Task<IActionResult> TraerFumador()
        {
            return Ok(await _pacienteRepo.Fumador());
        }
        [Route("menor")]
        [HttpGet]
        public async Task<IActionResult> TraerMenor()
        {
            return Ok(await _pacienteRepo.Menor());
        }
        [Route("mayor")]
        [HttpGet]
        public async Task<IActionResult> TraerMayor()
        {
            return Ok(await _pacienteRepo.Mayor());
        }

        [HttpPost]
        public async Task<IActionResult> CrearPaciente([FromBody] paciente p)
        {
            if (p == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _pacienteRepo.InsertPaciente(p);

            return Created("created", created);
        }

        [HttpPut("{documento}")]
        public async Task<IActionResult> ActualizarEstadoPaciente(String documento)
        {
            if (documento == null )
                return BadRequest();

            await _pacienteRepo.UpdateEstadoPaciente(documento);

            return NoContent();
        }

        [HttpDelete("{documento}")]
        public async Task<IActionResult> EliminarPaciente(String documento)
        {
            await _pacienteRepo.DetelePaciente(documento);

            return NoContent();
        }
    }
}
