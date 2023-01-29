using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPNewApi2.Tools;
using VG_ApiF.DTO;
using VG_ApiF.Models;

namespace VG_ApiF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizensController : ControllerBase
    {
        //for database connection
        private readonly VgDatabaseContext _context;

        private readonly IConfiguration _configuration;

        //private readonly UserManager<ApplicationUser> _userManager;
        public CitizensController(VgDatabaseContext _context, IConfiguration _configuration)
        {
            this._context = _context;
            this._configuration = _configuration;
        }


        //Citizens registrtation
        [HttpPost]
        [Route("Citizenregister")]
        public async Task<IActionResult> Merchantregister([FromBody] CitizenRegister citi)
        {
            try
            {
                var user11 = _context.Citizens.Where(u => u.CitiEmail == citi.CitiEmail).FirstOrDefault();
                if (user11 != null)
                {
                    return BadRequest("Citizen already existed");
                }
                else
                {
                    user11 = new Citizen();

                    user11.CitiName = citi.CitiName;
                    user11.CitiLastname = citi.CitiLastname;
                    user11.CitiEmail = citi.CitiEmail;
                    user11.CitiContactdetails = citi.CitiContactdetails;
                    user11.CitiAddress = citi.CitiAddress;
                    user11.CitiProvince = citi.CitiProvince;
                    user11.CitiCity = citi.CitiCity;
              
                    user11.CitiPassword = Password.hashPassword(citi.CitiPassword);
                    user11.CitiStatus = "Active";
                   
                    _context.Citizens.Add(user11);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "successful registered a citizen" });
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
