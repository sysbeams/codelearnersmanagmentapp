using System.ComponentModel;
namespace Domain.Enums;

public enum Mode
{
    [Description(nameof(Online))]
    Online = 1,
    [Description(nameof(Virtual))]
    Virtual = 2,
    [Description(nameof(Onsite))]
    Onsite = 3,
}
