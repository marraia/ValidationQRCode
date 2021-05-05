using Montenegro.QrCode.Validation.Core.Entities;
using Montenegro.QrCode.Validation.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace Montenegro.QrCode.Validation.Core
{
    public class SendValidation : ISendValidation
    {
        public readonly ISendInvitationValidation _sendInvitationValidation;
        public SendValidation(ISendInvitationValidation sendInvitationValidation)
        {
            _sendInvitationValidation = sendInvitationValidation;
        }
        public async Task<InvitationRequest> SendInvitationValidationAsync(Guid invitationId)
        {
            try
            {
                var validation = await _sendInvitationValidation
                                            .ValidatedInvitedAsync(invitationId, "123456")
                                            .ConfigureAwait(false);

                return validation;
            }
            catch(Refit.ApiException ex)
            {
                throw new Exception(ex.Content);
            }
        }
    }
}
