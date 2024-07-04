namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

public class Output : VentrisReverbSettingSmooth
{
    public Output()
    {
        MidiControlChangeName = "Output";
        MidiControlChangeDescription = "Sets Output";
        MidiControlChangeId = 6;
    }
}