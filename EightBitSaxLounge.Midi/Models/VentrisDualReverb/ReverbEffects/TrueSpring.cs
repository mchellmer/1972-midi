namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEffects;

public class TrueSpring : VentrisReverbEffect
{
    public TrueSpring()
    {
        MidiControlChangeValueName = "True Spring";
        MidiControlChangeValueId = 3;
        MidiControlChangeValueDescription = "True Spring reverb effect";
    }
}