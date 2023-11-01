using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;

namespace API.Controller;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<AppUser>> GetUsers()
    {
       var users = await  _context.Users.ToListAsync();

       return users;
       
    }
    [HttpGet("{id}")]

    public async Task<AppUser> GetUser(int id)
    {

        return await _context.Users.FindAsync(id);
    }
}

 