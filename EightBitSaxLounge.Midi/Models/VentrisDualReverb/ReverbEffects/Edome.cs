namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEffects;

public class Edome : VentrisReverbEffect
{
    public Edome()
    {
        MidiControlChangeValueName = "E-Dome";
        MidiControlChangeValueId = 2;
        MidiControlChangeValueDescription = "Edome reverb effect";
        ReverbEffectParameters = new List<VentrisReverbEffectParameter>
        {
            new()
            {
                EngineParameterId = 1,
                VentrisReverbEffectParameterName = "Pre-Delay Feedback High Cut"
            },
            new()
            {
                EngineParameterId = 2,
                VentrisReverbEffectParameterName = "Pre-Delay Feedback Low Cut"
            },
            new()
            {
                EngineParameterId = 3,
                VentrisReverbEffectParameterName = "Early Reflections Level"
            },
            new()
            {
                EngineParameterId = 4,
                VentrisReverbEffectParameterName = "Reverb Level"
            },
            new()
            {
                EngineParameterId = 5,
                VentrisReverbEffectParameterName = "Early/Reverb Crossfade"
            }
        };
    }
}