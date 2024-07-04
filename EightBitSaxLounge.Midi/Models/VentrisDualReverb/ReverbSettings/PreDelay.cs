namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

public class PreDelay : VentrisReverbSettingSmooth
{
    public PreDelay()
    {
        MidiControlChangeName = "Pre-Delay";
        MidiControlChangeDescription = "Sets Pre-Delay";
        MidiControlChangeId = 4;
    }
}