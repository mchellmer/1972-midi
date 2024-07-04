namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

public class Treble : VentrisReverbSettingSmooth
{
    public Treble()
    {
        MidiControlChangeName = "Treble";
        MidiControlChangeDescription = "Sets Treble";
        MidiControlChangeId = 5;
    }
}