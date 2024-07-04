namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEffects;

public class Offspring : VentrisReverbEffect
{
    public Offspring()
    {
        MidiControlChangeValueName = "Offspring";
        MidiControlChangeValueId = 10;
        MidiControlChangeValueDescription = "Offspring reverb effect";
        ReverbEffectParameters = new List<VentrisReverbEffectParameter>
        {
            new()
            {
                EngineParameterId = 1,
                VentrisReverbEffectParameterName = "Master Offset"
            },
            new()
            {
                EngineParameterId = 2,
                VentrisReverbEffectParameterName = "Master Pre-Delay"
            },
            new()
            {
                EngineParameterId = 3,
                VentrisReverbEffectParameterName = "Early Reflections"
            },
            new()
            {
                EngineParameterId = 4,
                VentrisReverbEffectParameterName = "Reverb Level"
            }
        };
    }
}