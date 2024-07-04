namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

public class PreDelayModDepth : VentrisReverbSettingSmooth
{
    public PreDelayModDepth()
    {
        MidiControlChangeName = "Pre-Delay Mod Depth";
        MidiControlChangeDescription = "Sets Pre-Delay Mod Depth";
        MidiControlChangeId = 12;
    }
}