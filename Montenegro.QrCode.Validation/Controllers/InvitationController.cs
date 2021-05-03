using Microsoft.AspNetCore.Mvc;
using Montenegro.QrCode.Validation.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace Montenegro.QrCode.Validation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationController : ControllerBase
    {
        public readonly ISendValidation _sendValidation;
        public InvitationController(ISendValidation sendValidation)
        {
            _sendValidation = sendValidation;
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put([FromRoute] Guid id)
        {
            try
            {
                var obj = await _sendValidation
                                    .SendInvitationValidationAsync(id)
                                    .ConfigureAwait(false);

                if (obj == null)
                    return NotFound();

                return Accepted("", obj);
            }
            catch(Refit.ApiException)
            {
                return BadRequest("Você não tem acesso ou o convite já foi validado!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
