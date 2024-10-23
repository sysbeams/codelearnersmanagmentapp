using System.ComponentModel;

namespace Domain.Enums
{
    public enum ContractType
    {
        [Description("Primary contract type")]
        Primary = 1,

        [Description("Adjunct contract type, often supplemental")]
        Adjunct = 2
    }
}