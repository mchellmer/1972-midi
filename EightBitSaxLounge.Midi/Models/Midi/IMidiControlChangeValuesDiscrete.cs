using EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb;

public interface IMidiControlChangeValuesDiscrete
{
    public List<MidiControlChangeValue> MidiControlChangeValues { get; set; }
}