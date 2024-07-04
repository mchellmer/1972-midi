namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

public class VentrisReverbSettingSmooth : VentrisReverbSetting, IMidiControlChangeValuesSmooth
{
    public int MidiControlChangeValueMin { get; set; } = 0;
    public int MidiControlChangeValueMax { get; set; } = 127;
}