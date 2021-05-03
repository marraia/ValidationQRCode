using Montenegro.QrCode.Validation.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Montenegro.QrCode.Validation.Core.Interfaces
{
    public interface ISendValidation
    {
        Task<InvitationRequest> SendInvitationValidationAsync(Guid invitationId);
    }
}
