using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "BasicAuthentication")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    } 

    [HttpGet]
    public async Task<IEnumerable<User>> Get()
    {
        return await _userRepository.Get();
    }
}