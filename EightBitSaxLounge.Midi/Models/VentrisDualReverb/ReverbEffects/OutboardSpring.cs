namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEffects;

public class OutboardSpring : VentrisReverbEffect
{
    public OutboardSpring()
    {
        MidiControlChangeValueName = "Outboard Spring";
        MidiControlChangeValueId = 12;
        MidiControlChangeValueDescription = "Outboard Spring reverb effect";
        ReverbEffectParameters = new List<VentrisReverbEffectParameter>
        {
            new()
            {
                EngineParameterId = 1,
                VentrisReverbEffectParameterName = "Drive (Dwell)"
            }
        };
    }
}