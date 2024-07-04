namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb;

public interface IMidiControlChange
{
    public string? MidiControlChangeName { get; set; }
    public string? MidiControlChangeDescription { get; set; }
    public int? MidiControlChangeId { get; set; }
}