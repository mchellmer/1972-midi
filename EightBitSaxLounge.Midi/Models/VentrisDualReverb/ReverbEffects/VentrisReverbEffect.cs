using EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEffects;

public class VentrisReverbEffect : MidiControlChangeValue
{
    public List<VentrisReverbEffectParameter>? ReverbEffectParameters { get; set; }
    public List<MidiControlChangeValue>? Sizes { get; set; }

    public void InitSizes(List<string> sizeNames)
    {
        Sizes = new List<MidiControlChangeValue>();
        for (int i = 0; i < sizeNames.Count; i++)
        {
            Sizes.Add(new MidiControlChangeValue
            {
                MidiControlChangeValueId = i,
                MidiControlChangeValueName = sizeNames[i],
                MidiControlChangeValueDescription = sizeNames[i]
            });
        }
    }
}