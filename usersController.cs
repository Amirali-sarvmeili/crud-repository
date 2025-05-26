using crud;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/[controller]")]
public class UsersContrller : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly EmailService _emailService;
    public UsersContrller(AppDbContext context,EmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }


//create user
    [HttpPost("api/Users")]
    public async Task<IActionResult>
        CreateUser([FromBody] user user)
    {
        _context.User.Add(user);
        await _context.SaveChangesAsync();
        await
            _emailService.SendEmailAsync(
                to: user.ایمیل,
                subject:"اطلاعات شما وارد شد",
                body:"اطلاعات شما با این ای دی وارد شد" +
                     $"                                                                         {user.ای_دی}" 
            );
        
        user.ای_دی= Guid.NewGuid();
        return Ok("اطلاعات کاربری وارد شد");
    }
// read (show all)
    [HttpGet]
    public async Task<IActionResult>
        GetAll() =>
        Ok(await
            _context.User.ToListAsync());
// read (show with user id)
[HttpGet("{id}")]
public async Task<IActionResult>
    Get(Guid id)
{
    var user = await
        _context.User.FindAsync(id);
    if (user == null) return NotFound("کاربری با این ای دی پیدا نشد ");
    return Ok(user);
}
// update
[HttpPut("{id}")]
public async Task<IActionResult>
    Update(Guid id , user updateUser)
{
    var user = await 
        _context.User.FindAsync(id);
    if (user == null) return NotFound("کاربری با این ای دی پیدا نشد");
    user.نام = updateUser.نام;
    user.شماره_تلفن = updateUser.شماره_تلفن;
    user.ایمیل = updateUser.ایمیل;
   await _context.SaveChangesAsync();
    return Ok(User);
}
// delete
[HttpDelete("{id}")]
public async Task<IActionResult>
    Delete (Guid id)
{
    var user = await _context.User.FindAsync(id);
    if (user == null) return NotFound("کاربری با این ای دی پیدا نشد");
    _context.User.Remove(user);
    await _context.SaveChangesAsync();
    return NoContent();
}
}
