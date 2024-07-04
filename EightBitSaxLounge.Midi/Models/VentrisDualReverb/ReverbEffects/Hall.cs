namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEffects;

public class Hall : VentrisReverbEffect
{
    public Hall()
    {
        MidiControlChangeValueName = "Hall";
        MidiControlChangeValueId = 1;
        MidiControlChangeValueDescription = "Hall reverb effect";
        ReverbEffectParameters = new List<VentrisReverbEffectParameter>
        {
            new()
            {
                EngineParameterId = 1,
                VentrisReverbEffectParameterName = "Diffusion Modulation Depth"
            }
        };
    }
}