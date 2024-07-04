namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEffects;

public class Room : VentrisReverbEffect
{
    public Room()
    {
        MidiControlChangeValueName = "Room";
        MidiControlChangeValueId = 0;
        MidiControlChangeValueDescription = "Sets Room Reverb";
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
        InitSizes(new List<string>
        {
            "room", "club", "stage", "arena", "e-dome", "dimension plate 1", "dimension plate 2", 
            "dimension spring 1", "dimension spring 2", "dimension modverb", "metal box"
        });
    }
}