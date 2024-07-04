namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

public class Bass : VentrisReverbSettingSmooth
{
    public Bass()
    {
        MidiControlChangeName = "Bass";
        MidiControlChangeDescription = "Sets Bass";
        MidiControlChangeId = 7;
    }
}