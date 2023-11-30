using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        // Taking the DataContext parameter given in the constructor and assigning
        // it to the private readonly context field in the UsersController Class and make it avaiable to this controller
        _context = context;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();

        return users;
    }

    
    [HttpGet("{id}")] //  api/users/2
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        //var user = _context.Users.Find(id);

        return await _context.Users.FindAsync(id);

    }
}
