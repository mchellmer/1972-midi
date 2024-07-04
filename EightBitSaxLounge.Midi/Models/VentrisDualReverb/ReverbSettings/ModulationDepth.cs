namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

public class ModulationDepth : VentrisReverbSettingSmooth
{
    public ModulationDepth()
    {
        MidiControlChangeName = "Modulation Depth";
        MidiControlChangeDescription = "Sets Modulation Depth";
        MidiControlChangeId = 9;
    }
}