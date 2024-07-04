namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

public class InputLowCut : VentrisReverbSetting, IMidiControlChangeValuesDiscrete
{
    public InputLowCut()
    {
        MidiControlChangeName = "Input Low Cut";
        MidiControlChangeDescription = "Sets Input Low Cut Frequency";
        MidiControlChangeId = 14;
        MidiControlChangeValues = new List<MidiControlChangeValue>
        {
            new() { MidiControlChangeValueName = "Offspring", MidiControlChangeValueId = 0, MidiControlChangeValueDescription = "Offspring" },
            new() { MidiControlChangeValueName = "20Hz", MidiControlChangeValueId = 1, MidiControlChangeValueDescription = "20Hz" },
            new() { MidiControlChangeValueName = "100Hz", MidiControlChangeValueId = 2, MidiControlChangeValueDescription = "100Hz" },
            new() { MidiControlChangeValueName = "125Hz", MidiControlChangeValueId = 3, MidiControlChangeValueDescription = "125Hz" },
            new() { MidiControlChangeValueName = "150Hz", MidiControlChangeValueId = 4, MidiControlChangeValueDescription = "150Hz" },
            new() { MidiControlChangeValueName = "200Hz", MidiControlChangeValueId = 5, MidiControlChangeValueDescription = "200Hz" },
            new() { MidiControlChangeValueName = "250Hz", MidiControlChangeValueId = 6, MidiControlChangeValueDescription = "250Hz" },
            new() { MidiControlChangeValueName = "Default Setting", MidiControlChangeValueId = 6, MidiControlChangeValueDescription = "Default Setting" },
        };
    }
    public List<MidiControlChangeValue> MidiControlChangeValues { get; set; }
}