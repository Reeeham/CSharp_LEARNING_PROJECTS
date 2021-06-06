using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyingAttributes
{
   
    // Assign description using a "named property."
    [Serializable]
    [VehicleDescription(Description = "My rocking Harley")]//named property syntax
    //can be persisted in a binary format, This class can be saved to disk.
    public class Motorcycle
    {
        // However, this field will not be persisted.
        [NonSerialized]
        float weightOfCurrentPassengers;
        // These fields are still serializable.
        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;
    }
    [Serializable]
    [Obsolete("Use another vehicle!")]
    [VehicleDescription("The old gray mare, she ain't what she used to be...")]
    public class HorseAndBuggy
    {
    }
    [VehicleDescription("A very long, slow, but feature-rich auto")]
    public class Winnebago
    {
    }
}
