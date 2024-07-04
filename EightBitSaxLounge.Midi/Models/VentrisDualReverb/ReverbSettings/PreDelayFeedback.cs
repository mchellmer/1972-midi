namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

public class PreDelayFeedback : VentrisReverbSettingSmooth
{
    public PreDelayFeedback()
    {
        MidiControlChangeName = "Pre-Delay Feedback";
        MidiControlChangeDescription = "Sets Pre-Delay Feedback";
        MidiControlChangeId = 11;
    }
}