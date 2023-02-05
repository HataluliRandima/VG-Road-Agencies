using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SPNewApi2.Tools;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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

       
        public CitizensController(VgDatabaseContext _context, IConfiguration _configuration)
        {
            this._context = _context;
            this._configuration = _configuration;
        }


        //Citizens registrtation
        [HttpPost]
        [Route("Citizenregister")]
        public async Task<IActionResult> Citizenregister([FromBody] CitizenRegister citi)
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


        //for creating the jwt token
        private JwtSecurityToken getToken(List<Claim> authClaim)
        {

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken
            (
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(24),
                claims: authClaim,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        //for log in the Citizens 
        [HttpPost]
        [Route("merchantlogin")]
        public async Task<IActionResult> Citizenlogin([FromBody] CitizenLogin user)
        {
            try
            {
                String password = Password.hashPassword(user.CitiPassword);
                var user11 = _context.Citizens.Where(u => u.CitiEmail == user.CitiEmail && u.CitiPassword == password).FirstOrDefault();
                if (user11 == null)
                {
                    return BadRequest("Either email or password is incorrect!!");
                }
                else
                {
                    List<Claim> authClaim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user11.CitiEmail),
                        new Claim ("citiID",user11.CitiId.ToString())
                    };

                    var token = this.getToken(authClaim);

                    return Ok(new
                    {
                        message = "Citizen login in the system",
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });

                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //Get all  Citizens
        [HttpGet]
        [Route("getallcitizens")]
        public async Task<IActionResult> getallCitizens()
        {

            try
            {
                List<Citizen> listuser = _context.Citizens.ToList();
                if (listuser != null)
                {
                    return Ok(listuser);
                }
                return Ok("They are no Citizens in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        //Get all MerchanCitizens by dscending order and status is active
        [HttpGet]
        [Route("getcitizensDesc")]
        public async Task<IActionResult> getallCitizensDescending()
        {

            try
            {
                List<Citizen> listuser = _context.Citizens.Where(u => u.CitiStatus == "Active").OrderByDescending(t => t.CitiId).ToList();
                if (listuser != null)
                {
                    return Ok(listuser);
                }
                return Ok("They are no Citizens in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //get citizen  by an ID
        [HttpGet]
        [Route("citizenby/{id}")]
        public async Task<IActionResult> getcitizenid(int id)
        {

            var user11 = _context.Citizens.Select(t => new
            {
                t.CitiId,
                t.CitiName,
                t.CitiLastname,
                t.CitiEmail,
                t.CitiContactdetails,
                t.CitiAddress,
                t.CitiCity,
                t.CitiProvince,
                t.CitiStatus
               
            }).Where(u => u.CitiId == id).FirstOrDefault();

            if (user11 == null)
            {
                return BadRequest("Cant find the specific citizen");

            }

            return Ok(user11);
            

        }


        //Getting current loged citizen in the system
        [HttpGet]
        [Route("citizen/current")]
        public async Task<IActionResult> getcurrentcitizen()
        {
            int id = Convert.ToInt32(HttpContext.User.FindFirstValue("citiID"));

            if (id == null || id <= 0)
            {
                return BadRequest("You are not log in");
            }
            var user11 = _context.Citizens.Select(t => new
            {
                t.CitiId,
                t.CitiName,
                t.CitiLastname,
                t.CitiEmail,
                t.CitiContactdetails,
                t.CitiAddress,
                t.CitiCity,
                t.CitiProvince,
                t.CitiStatus
            }).Where(u => u.CitiId == id).FirstOrDefault();

            return Ok(user11);

            
        }


        //Edit the citizen profile
        [HttpPut]
        [Route("editcitizen/{id}")]
        public async Task<ActionResult> userupdate([FromBody] Editcitizen user, int id)
        {

            int userID = Convert.ToInt32(HttpContext.User.FindFirstValue("citiID"));

  
            var dbu = await _context.Citizens.FindAsync(id);
            if (userID == null || userID <= 0)
            {
                return BadRequest("YOu are not log in");
            }
            if (dbu == null)
            {
                return BadRequest("citizen not found");
            }

            dbu.CitiName = user.CitiName;
            dbu.CitiLastname = user.CitiLastname;
            dbu.CitiContactdetails = user.CitiContactdetails;
            dbu.CitiAddress = user.CitiAddress;
            dbu.CitiProvince = user.CitiProvince;
            dbu.CitiCity = user.CitiCity;

            await _context.SaveChangesAsync();

            return Ok(await _context.Citizens.ToListAsync());
        }

        //delete specific citizen
        [HttpDelete]
        [Route("deletecitizen/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {

            int userID = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));

            //var dbu = _context.Clients.Where(u => u.UserId == id).FirstOrDefault();

            var ttt = await _context.Citizens.FindAsync(id);
            if (userID == null || userID <= 0)
            {
                return BadRequest("YOu are not log in");
            }

            if (ttt == null)
            {
                return BadRequest("citizen not found");
            }

            _context.Citizens.Remove(ttt);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Citizen deleted" });
        }




    }
}
