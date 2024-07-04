namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

public class EngineSpecialControl : VentrisReverbSetting, IMidiControlChangeValuesDiscrete
{
    public EngineSpecialControl()
    {
        MidiControlChangeName = "Engine Special Control";
        MidiControlChangeDescription = "Special control parameters for the engine";
        MidiControlChangeId = 20;
    }
    public List<MidiControlChangeValue> MidiControlChangeValues { get; set; }
}