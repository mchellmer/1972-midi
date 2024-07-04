namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

public class Size : VentrisReverbSetting
{
    public Size()
    {
        MidiControlChangeName = "Size";
        MidiControlChangeDescription = "Sets Size (engine dependent)";
        MidiControlChangeId = 13;
    }

    // Method to set the maximum value based on the engine type
    // public void SetMaxValueBasedOnEngine(string engineType)
    // {
    //     switch (engineType.ToLower())
    //     {
    //         case "hall":
    //             MidiControlChangeValueMax = 5;
    //             break;
    //         case "echoverb":
    //             MidiControlChangeValueMax = 1;
    //             break;
    //         case "room":
    //             MidiControlChangeValueMax = 10;
    //             break;
    //         case "e-dome":
    //             MidiControlChangeValueMax = 10;
    //             break;
    //         case "plate":
    //             MidiControlChangeValueMax = 2;
    //             break;
    //         case "lo-fi":
    //             MidiControlChangeValueMax = 4;
    //             break;
    //         case "modverb":
    //             MidiControlChangeValueMax = 5;
    //             break;
    //         case "shimmer":
    //             MidiControlChangeValueMax = 5;
    //             break;
    //         case "swell":
    //             MidiControlChangeValueMax = 4;
    //             break;
    //         case "offspring":
    //             MidiControlChangeValueMax = 0;
    //             break;
    //         case "reverse":
    //             MidiControlChangeValueMax = 0;
    //             break;
    //         case "outboard spring":
    //             MidiControlChangeValueMax = 5;
    //             break;
    //         case "metal box":
    //             MidiControlChangeValueMax = 10;
    //             break;
    //         default:
    //             throw new ArgumentException("Unknown engine type", nameof(engineType));
    //     }
    // }
}