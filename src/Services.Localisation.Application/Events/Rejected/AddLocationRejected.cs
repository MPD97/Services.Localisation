using Convey.CQRS.Events;

namespace Services.Localisation.Application.Events.Rejected
{
    [Contract]
    public class AddLocationRejected: IRejectedEvent
    {
        public string Reason { get; }
        public string Code { get; }

        public AddLocationRejected(string reason, string code)
        {
            Reason = reason;
            Code = code;
        }
    }
}