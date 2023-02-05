using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class OfficialsController : ControllerBase
    {

        //for database connection
        private readonly VgDatabaseContext _context;

        private readonly IConfiguration _configuration;


        public OfficialsController(VgDatabaseContext _context, IConfiguration _configuration)
        {
            this._context = _context;
            this._configuration = _configuration;
        }


        //Officials registrtation
        [HttpPost]
        [Route("Officialregister")]
        public async Task<IActionResult> Officialregister([FromBody] OfficialRegister ofi)
        {
            try
            {
                var user11 = _context.Officials.Where(u => u.OfiEmail == ofi.OfiEmail).FirstOrDefault();
                if (user11 != null)
                {
                    return BadRequest("Official already existed");
                }
                else
                {
                    user11 = new Official();

                    user11.OfiName = ofi.OfiName;
                    user11.OfiLastname = ofi.OfiLastname;
                    user11.OfiEmail = ofi.OfiEmail;
                    user11.OfiContactdetails = ofi.OfiContactdetails;
                    user11.OfiAddress = ofi.OfiAddress;
                    user11.OfiBadge = ofi.OfiBadge;
                    user11.OfiType = ofi.OfiType;
                    user11.OfiPassword = Password.hashPassword(ofi.OfiPassword);
                    user11.OfiStatus = "Active";

                    _context.Officials.Add(user11);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "successful registered an offial" });
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

        //for log in the officials 
        [HttpPost]
        [Route("officiallogin")]
        public async Task<IActionResult> Citizenlogin([FromBody] OfficialLogin user)
        {
            try
            {
                String password = Password.hashPassword(user.OfiPassword);
                var user11 = _context.Officials.Where(u => u.OfiEmail == user.OfiEmail && u.OfiPassword == password).FirstOrDefault();
                if (user11 == null)
                {
                    return BadRequest("Either email or password is incorrect!!");
                }
                else
                {
                    List<Claim> authClaim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user11.OfiEmail),
                        new Claim ("ofiID",user11.OfiId.ToString())
                    };

                    var token = this.getToken(authClaim);

                    return Ok(new
                    {
                        message = "official login in the system",
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


        //Get all  officials
        [HttpGet]
        [Route("getallcitizens")]
        public async Task<IActionResult> getallofficials()
        {

            try
            {
                List<Official> listuser = _context.Officials.ToList();
                if (listuser != null)
                {
                    return Ok(listuser);
                }
                return Ok("They are no officials in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        //Get all officials by dscending order and status is active
        [HttpGet]
        [Route("getcitizensDesc")]
        public async Task<IActionResult> getallCitizensDescending()
        {

            try
            {
                List<Official> listuser = _context.Officials.Where(u => u.OfiStatus == "Active").OrderByDescending(t => t.OfiId).ToList();
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


        //get official  by an ID
        [HttpGet]
        [Route("officialby/{id}")]
        public async Task<IActionResult> getofficialid(int id)
        {

            var user11 = _context.Officials.Select(t => new
            {
                t.OfiId,
                t.OfiName,
                t.OfiLastname,
                t.OfiEmail,
                t.OfiContactdetails,
                t.OfiAddress,
                t.OfiStatus,
                t.OfiBadge,
                t.OfiType

            }).Where(u => u.OfiId == id).FirstOrDefault();

            if (user11 == null)
            {
                return BadRequest("Cant find the specific official");

            }

            return Ok(user11);


        }


        //Getting current loged official in the system
        [HttpGet]
        [Route("official/current")]
        public async Task<IActionResult> getcurrentofficial()
        {
            int id = Convert.ToInt32(HttpContext.User.FindFirstValue("ofiID"));

            if (id == null || id <= 0)
            {
                return BadRequest("You are not log in");
            }
            var user11 = _context.Officials.Select(t => new
            {
                t.OfiId,
                t.OfiName,
                t.OfiLastname,
                t.OfiEmail,
                t.OfiContactdetails,
                t.OfiAddress,
                t.OfiStatus,
                t.OfiBadge,
                t.OfiType
            }).Where(u => u.OfiId == id).FirstOrDefault();

            return Ok(user11);


        }




    }
}
