using AutoMapper;
using Identity6.Data.DTOs;
using Identity6.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity6.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public UsuarioService(UserManager<Usuario> userManager, IMapper mapper
            , SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task Cadastra(CreateUsuarioDTO dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            var res = await _userManager.CreateAsync(usuario, dto.Password);

            if (!res.Succeeded) throw new ApplicationException("Falha ao cadastrar usuario!");            
        }

        public async Task<string> Login(LoginUsuarioDTO dto)
        {
            var res = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!res.Succeeded) throw new ApplicationException("Usuário não autenticado!");

            var usuario = _signInManager.UserManager.Users
                .FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(usuario);

            return token;
        }
    }
}
