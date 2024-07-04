namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

public class EngineSpecialControl : VentrisReverbSettingSmooth
{
    public EngineSpecialControl()
    {
        MidiControlChangeName = "Engine Special Control";
        MidiControlChangeDescription = "Special control parameters for the engine";
        MidiControlChangeId = 20;
    }
}