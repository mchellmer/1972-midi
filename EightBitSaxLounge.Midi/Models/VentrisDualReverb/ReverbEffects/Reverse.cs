namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEffects;

public class Reverse : VentrisReverbEffect
{
    public Reverse()
    {
        MidiControlChangeValueName = "Reverse";
        MidiControlChangeValueId = 11;
        MidiControlChangeValueDescription = "Reverse reverb effect";
        ReverbEffectParameters = new List<VentrisReverbEffectParameter>
        {
            new()
            {
                EngineParameterId = 1,
                VentrisReverbEffectParameterName = "Delay Curve Shape (0-5 knob mapped)"
            },
            new()
            {
                EngineParameterId = 2,
                VentrisReverbEffectParameterName = "Curve Filtering (0-2 knob mapped)"
            }
        };
    }
}