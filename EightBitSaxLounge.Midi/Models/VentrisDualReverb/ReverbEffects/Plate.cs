namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEffects;

public class Plate : VentrisReverbEffect
{
    public Plate()
    {
        MidiControlChangeValueName = "Plate";
        MidiControlChangeValueId = 4;
        MidiControlChangeValueDescription = "Plate reverb effect";
        ReverbEffectParameters = new List<VentrisReverbEffectParameter>
        {
            new()
            {
                EngineParameterId = 1,
                VentrisReverbEffectParameterName = "Metallic Mix"
            },
            new()
            {
                EngineParameterId = 2,
                VentrisReverbEffectParameterName = "Reverb Level"
            },
            new()
            {
                EngineParameterId = 3,
                VentrisReverbEffectParameterName = "Early Reflections Level"
            }
        };
    }
}