namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

public class Mix : VentrisReverbSettingSmooth
{
    public Mix()
    {
        MidiControlChangeName = "Mix";
        MidiControlChangeDescription = "Sets the wet/dry mix - 50/50 point at approx. 95";
        MidiControlChangeId = 3;
    }
}