using RedeSocial_Auth.Application.Interfaces;
using RedeSocial_Auth.Domain.Models.Users;
using RedeSocial_Auth.Application.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc;

namespace RedeSocial_Auth.WebApi.Controllers;

/// <summary>
/// Controller responsável por gerenciar usuários
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService userService, IMapper mapper, ILogger<UserController> logger)
    {
        _userService = userService;
        _mapper = mapper;
        _logger = logger;
    }

    private IActionResult HandleError(Exception ex, string message)
    {
        _logger.LogError(ex, message);
        return StatusCode(500, new { message, error = ex.Message });
    }

    private IActionResult SuccessResponse(object? data, string message)
    {
        return Ok(new { message, data });
    }

    /// <summary>
    /// Retorna todos os usuários cadastrados
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetAsync()
    {
        var users = await _userService.GetUsers();

        if (users == null || !users.Any())
        {
            return NoContent();
        }

        var usersDTO = _mapper.Map<List<UserDTO>>(users);

        return SuccessResponse(usersDTO, "Usuários retornados com sucesso");
    }

    /// <summary>
    /// Retorna um usuário pelo ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        try
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound(new { message = $"Usuário com o ID {id} não encontrado" });
            }

            var userDTO = _mapper.Map<UserDTO>(user);

            return SuccessResponse(userDTO, "Usuário encontrado com sucesso");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "Erro ao buscar usuário");
        }
    }

    /// <summary>
    /// Cria um novo usuário
    /// </summary>
    /// <param name="body"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] User body)
    {
        try
        {
            if (body == null)
            {
                return BadRequest(new { message = "Dados do usuário são inválidos" });
            }

            var user = _mapper.Map<User>(body);
            var newUser = await _userService.AddUser(user);

            var newUserDTO = _mapper.Map<UserDTO>(newUser);

            return SuccessResponse(newUserDTO, "Usuário adicionado com sucesso");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "Erro ao adicionar usuário");
        }
    }

    /// <summary>
    /// Deleta um usuário pelo ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        try
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound(new { message = $"Usuário com o ID {id} não encontrado" });
            }

            await _userService.DeleteUser(id);
            return SuccessResponse(null, "Usuário deletado com sucesso");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "Erro ao deletar usuário");
        }
    }

    /// <summary>
    /// Atualiza um usuário
    /// </summary>
    /// <param name="id"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] User body)
    {
        try
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound(new { message = $"Usuário com o ID {id} não encontrado" });
            }

            var updatedUser = _mapper.Map<User>(body);
            updatedUser.Id = id;

            var newUser = await _userService.UpdateUser(id, updatedUser);

            var newUserDTO = _mapper.Map<UserDTO>(newUser);

            return SuccessResponse(newUserDTO, "Usuário atualizado com sucesso");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "Erro ao atualizar usuário");
        }
    }
}