using ApiCnt.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebAplication.Models;

namespace WebAplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(paciente p)
        {
            
            return View();
        }

        public async Task<IActionResult> NuevoPaciente(paciente p)
        {
            Console.WriteLine(p);
            metodosComplementarios m = new metodosComplementarios();
            var Pcompleto = m.PrioridadYRiesgo(p);
            var httpClient = new HttpClient();
            var respuesta = await httpClient.PostAsJsonAsync("https://localhost:44388/api/pacientes", Pcompleto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Pacientes(string parametro)
        {
            //https://localhost:44388/api/pacientes/prioridad

            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://localhost:44388/api/pacientes/"+parametro);
            var pacientesLista = JsonConvert.DeserializeObject<List<paciente>>(json);
            return View(pacientesLista);
        }

        public async Task<IActionResult> Atender(string documento)
        {
            //https://localhost:44388/api/pacientes/prioridad

            var httpClient = new HttpClient();
            var requestContent = new StringContent(documento, Encoding.UTF8, "application/json");
            await httpClient.PutAsync("https://localhost:44388/api/pacientes/"+documento, requestContent);
            
            return RedirectToAction("Pacientes", new { parametro = "prioridad" });
        }

        public async Task<IActionResult> Personas(string documento)
        {
            //https://localhost:44388/api/pacientes/prioridad
            
            var httpClient = new HttpClient();
            var jsonf = await httpClient.GetStringAsync("https://localhost:44388/api/pacientes/fumador" );
            var jsonMe = await httpClient.GetStringAsync("https://localhost:44388/api/pacientes/menor");
            var jsonMa = await httpClient.GetStringAsync("https://localhost:44388/api/pacientes/mayor");
            var personaf = JsonConvert.DeserializeObject<List<paciente>>(jsonf);
            var personaMe = JsonConvert.DeserializeObject<List<paciente>>(jsonMa);
            var personaMa = JsonConvert.DeserializeObject<List<paciente>>(jsonMe);

            List<paciente> listaPersonas = new List<paciente>();
            listaPersonas.Add(personaf.ElementAt(0));
            listaPersonas.Add(personaMa.ElementAt(0));
            listaPersonas.Add(personaMe.ElementAt(0));
            ViewBag.personas = listaPersonas;
            return View();


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
