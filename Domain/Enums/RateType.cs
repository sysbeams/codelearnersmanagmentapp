using System.ComponentModel;

namespace Domain.Enums
{
    public enum RateType
    {
        [Description("Monthly rate for services or subscriptions")]
        Monthly = 1,

        [Description("Rate charged per class or session")]
        PerClass = 2
    }
}