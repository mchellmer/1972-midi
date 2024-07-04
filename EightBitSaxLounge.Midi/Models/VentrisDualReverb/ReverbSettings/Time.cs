namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

public class Time : VentrisReverbSettingSmooth
{
    public Time()
    {
        MidiControlChangeName = "Time";
        MidiControlChangeDescription = "Sets min and max delay times";
        MidiControlChangeId = 2;
    }
}