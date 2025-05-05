using Microsoft.AspNetCore.Mvc;
using WebForms.Application.DTOs;
using WebForms.Application.Services;
using WebForms.Core.Models;

namespace WebForms.Controllers;


[ApiController]
[Route("users")]
public class UsersController(UsersService usersService) : ControllerBase
{
    [HttpGet("get")]
    public async Task<IActionResult> GetAllUsers()
    {
        List<User> users = await usersService.GetAllUsers();
        
        return Ok(users);
    }

    [HttpPost("authorize")]
    public async Task<IActionResult> Authorize([FromBody] AuthorizeUserDto authorizeUserDto)
    {
        try
        {
            User user = await usersService.Authorize(authorizeUserDto);

            return Ok(user);
        }
        catch (KeyNotFoundException ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddUser([FromBody] AddUserDto addUserDto)
    {
        try
        {
            ulong userId = await usersService.AddUser(addUserDto);
            
            return Ok(userId);
        }
        catch (Exception e)
        {
            throw new Exception("Error while adding user", e);
        }
    }
    
}