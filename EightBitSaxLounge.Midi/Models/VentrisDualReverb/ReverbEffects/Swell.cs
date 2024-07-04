namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEffects;

public class Swell : VentrisReverbEffect
{
    public Swell()
    {
        MidiControlChangeValueName = "Swell";
        MidiControlChangeValueId = 9;
        MidiControlChangeValueDescription = "Swell reverb effect";
        ReverbEffectParameters = new List<VentrisReverbEffectParameter>
        {
            new()
            {
                EngineParameterId = 1,
                VentrisReverbEffectParameterName = "Envelope Gain"
            },
            new()
            {
                EngineParameterId = 2,
                VentrisReverbEffectParameterName = "Swell Time"
            },
            new()
            {
                EngineParameterId = 3,
                VentrisReverbEffectParameterName = "Swell Send Signal"
            },
            new()
            {
                EngineParameterId = 4,
                VentrisReverbEffectParameterName = "Swell Dry Signal"
            }
        };
    }
}