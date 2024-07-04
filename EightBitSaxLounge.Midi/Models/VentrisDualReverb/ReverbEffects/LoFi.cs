using EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEffects;

public class LoFi : VentrisReverbEffect
{
    string EngineSpecialControl { get; set; }
    public LoFi()
    {
        MidiControlChangeValueName = "Lo-Fi";
        MidiControlChangeValueId = 5;
        MidiControlChangeValueDescription = "Lo-Fi reverb effect";
        EngineSpecialControl = "Modulation Noise Depth";
        ReverbEffectParameters = new List<VentrisReverbEffectParameter>
        {
            new()
            {
                EngineParameterId = 1,
                VentrisReverbEffectParameterName = "Distortion (Drive)"
            },
            new()
            {
                EngineParameterId = 2,
                VentrisReverbEffectParameterName = "Quantize (0-9 knob mapped)"
            },
            new()
            {
                EngineParameterId = 3,
                VentrisReverbEffectParameterName = "Sample Rate Reduction"
            },
            new()
            {
                EngineParameterId = 4,
                VentrisReverbEffectParameterName = "Destruct/Clean Mix"
            },
            new()
            {
                EngineParameterId = 5,
                VentrisReverbEffectParameterName = "Destruct High Cut"
            }
        };
    }
}