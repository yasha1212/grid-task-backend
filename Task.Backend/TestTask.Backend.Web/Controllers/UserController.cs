using Microsoft.AspNetCore.Mvc;
using TestTask.Backend.DataAccess.Entities;
using TestTask.Backend.DataAccess.Repositories.Users;

namespace TestTask.Backend.Web.Controllers;

public class UserController : ApiController
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var users = await _userRepository.GetAllAsync();

            return Ok(users);
        }
        catch (Exception e) 
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(User user)
    {
        try
        {
            await _userRepository.AddAsync(user);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(User user)
    {
        try
        {
            await _userRepository.UpdateAsync(user);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _userRepository.DeleteAsync(id);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}

