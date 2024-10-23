using System.ComponentModel;

namespace Domain.Enums
{
    public enum ContractStatus
    {
        [Description("Currently active contract")]
        Active = 1,

        [Description("Contract that is not currently active")]
        InActive = 2,

        [Description("Contract that has been terminated")]
        Terminated = 3
    }
}