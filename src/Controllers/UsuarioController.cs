using AutoMapper;
using Identity6.Data.DTOs;
using Identity6.Models;
using Identity6.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity6.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("Cadastro")]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDTO dto)
        {
            await _usuarioService.Cadastra(dto);

            return Ok("Usuario cadastrado");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUsuarioDTO dto)
        {
            return Ok(await _usuarioService.Login(dto));
        }
    }
}
