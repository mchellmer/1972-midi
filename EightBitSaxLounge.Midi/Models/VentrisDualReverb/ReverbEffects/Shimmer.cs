namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEffects;

public class Shimmer : VentrisReverbEffect
{
    public Shimmer()
    {
        MidiControlChangeValueName = "Shimmer";
        MidiControlChangeValueId = 7;
        MidiControlChangeValueDescription = "Shimmer reverb effect";
        ReverbEffectParameters = new List<VentrisReverbEffectParameter>
        {
            new()
            {
                EngineParameterId = 1,
                VentrisReverbEffectParameterName = "Pitch Shift/Normal Crossfade"
            },
            new()
            {
                
                EngineParameterId = 2,
                VentrisReverbEffectParameterName = "Pitch Shift Modulation"
            },

            new()
            {
                EngineParameterId = 4,
                VentrisReverbEffectParameterName = "Pitch Interval (0-26 no mapping)"
            },
            new()
            {
                EngineParameterId = 5,
                VentrisReverbEffectParameterName = "Pitch Feedback (Regen)"
            }
        };
    }
}