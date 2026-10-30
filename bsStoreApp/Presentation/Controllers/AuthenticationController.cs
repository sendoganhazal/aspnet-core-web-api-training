using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController ( IServiceManager service )
        {
            _service = service;
        }

        [HttpPost("register")]
        [ServiceFilter ( typeof(ValidationFilterAttribute) )]
        public async Task<IActionResult> RegisterUser ( [FromBody]UserForRegistirationDto userForRegistirationDto ) 
        { 
            var result = await _service
                .AuthenticationService
                .RegisterUser(userForRegistirationDto);

            if ( !result.Succeeded )
            {
                foreach ( var error in result.Errors )
                {
                    ModelState.TryAddModelError ( error.Code, error.Description );
                }
                return BadRequest ( ModelState );
            }

            return StatusCode ( 201 );

        }

        [HttpPost ( "login" )]
        [ServiceFilter ( typeof ( ValidationFilterAttribute ) )]
        public async Task<IActionResult> Authenticate ( [FromBody] UserForAuthenticationDto user )
        {
            if ( !await _service.AuthenticationService.ValidateUser ( user ) )
                return Unauthorized ( ); // 401

            return Ok ( new
                {
                    Token = await _service.AuthenticationService.CreateToken ( )
                }
            );
        }
    }
}
