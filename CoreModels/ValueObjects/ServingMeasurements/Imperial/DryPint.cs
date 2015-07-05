using Core.Abstracts;

namespace Core.ValueObjects
{
    public class DryPint : Measure
    {
        public DryPint(double servingSize)
            : base(servingSize, "pt")
        {
            FriendlyName = "pint";
            FriendlyNamePlural = "pints";
        }
    }
}