namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

public class ModulationRate : VentrisReverbSettingSmooth
{
    public ModulationRate()
    {
        MidiControlChangeName = "Modulation Rate";
        MidiControlChangeDescription = "Sets Modulation Rate";
        MidiControlChangeId = 10;
    }
}