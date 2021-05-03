using System;

namespace Montenegro.QrCode.Validation.Core.Entities
{
    public class InvitationRequest
    {
        public Guid InvitationId { get; set; }
        public string Celebration { get; set; }
        public string Name { get; set; }
        public int TotalInvitation { get; set; }
        public int TotalConfirmed { get; set; }
        public bool Confirm { get; set; }
    }
}
