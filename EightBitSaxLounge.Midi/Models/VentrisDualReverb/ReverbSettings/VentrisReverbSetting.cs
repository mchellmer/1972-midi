namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

public class VentrisReverbSetting : IMidiControlChange
{
    public string? MidiControlChangeName { get; set; }
    public string? MidiControlChangeDescription { get; set; }
    public int? MidiControlChangeId { get; set; }
}