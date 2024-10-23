using System.ComponentModel;

namespace Domain.Enums
{
    public enum EducationLevel
    {
        [Description(nameof(Phd))]
        Phd = 1,
        [Description(nameof(MSc))]
        MSc,
        [Description(nameof(BSc))]
        BSc,
        [Description(nameof(SSCE))]
        SSCE,
        [Description(nameof(Others))]
        Others
    }
}
