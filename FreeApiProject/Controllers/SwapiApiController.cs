using FreeApiProject.Models;
using FreeApiProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwapiApiController : ControllerBase
    {
        private readonly IHttpClientService _httpClient;

        public SwapiApiController(IHttpClientService httpClient)
        {
            _httpClient = httpClient;
            _httpClient.AddBaseUrl("https://swapi.dev/api/");
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = await _httpClient.GetAsync<Films>($"films");
            return Ok(query);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = await _httpClient.GetAsync<Film>($"films/{id}");
            return Ok(query);
        }
    }
}
