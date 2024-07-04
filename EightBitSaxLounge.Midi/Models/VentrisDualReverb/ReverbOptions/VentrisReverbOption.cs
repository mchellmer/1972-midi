namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbOptions;

public class VentrisReverbOption
{
    public int MidiControlChangeId { get; set; }
    public string? VentrisReverbOptionName { get; set; }
    public string? VentrisReverbOptionDescription { get; set; }
    public string? VentrisReverbOptionValueMin { get; set; }
    public string? VentrisReverbOptionValueMax { get; set; }
}