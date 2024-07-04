namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

public class Diffusion : VentrisReverbSettingSmooth
{
    public Diffusion()
    {
        MidiControlChangeName = "Diffusion";
        MidiControlChangeDescription = "Sets Diffusion";
        MidiControlChangeId = 8;
    }
}