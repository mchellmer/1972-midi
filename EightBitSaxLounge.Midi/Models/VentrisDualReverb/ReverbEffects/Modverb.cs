namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEffects;

public class Modverb : VentrisReverbEffect
{
    public Modverb()
    {
        MidiControlChangeValueName = "Modverb";
        MidiControlChangeValueId = 6;
        MidiControlChangeValueDescription = "Modverb reverb effect with tremolo";
        ReverbEffectParameters = new List<VentrisReverbEffectParameter>
        {
            new()
            {
                EngineParameterId = 1,
                VentrisReverbEffectParameterName = "Tremolo Depth"
            },
            new()
            {
                EngineParameterId = 2,
                VentrisReverbEffectParameterName = "Tremolo Rate"
            },
            new()
            {
                EngineParameterId = 3,
                VentrisReverbEffectParameterName = "Tremolo Shape (0-4 knob mapped)"
            },
            new()
            {
                EngineParameterId = 4,
                VentrisReverbEffectParameterName = "Tremolo Options (0-7 knob mapped)"
            },
            new()
            {
                EngineParameterId = 5,
                VentrisReverbEffectParameterName = "Tremolo Stereo Spread"
            }
        };
    }
}