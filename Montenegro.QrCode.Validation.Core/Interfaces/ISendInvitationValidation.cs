using Montenegro.QrCode.Validation.Core.Entities;
using Refit;
using System;
using System.Threading.Tasks;

namespace Montenegro.QrCode.Validation.Core.Interfaces
{
    public interface ISendInvitationValidation
    {
        [Get("/Invitation/{id}/Validate/{validated}")]
        Task<InvitationRequest> ValidatedInvitedAsync(Guid id, string validated);
    }
}
