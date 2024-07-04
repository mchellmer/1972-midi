namespace EightBitSaxLounge.Midi.Models.Midi;

class MidiCcMessage : MidiMessage
{
    private MidiCcMsgDefs _msgType;

    public MidiCcMessage(MidiCcMsgDefs msgType)
    {
        _msgType = msgType;
    }

    // public void Send(MidiOutDevice dev, int cc, int value)
    // {
    //     int channel = 0; // MIDI channels are 0-indexed
    //     int status = 0xB0 + channel; // No need to subtract 1 from channel because it's already 0
    //
    //     uint message = (uint)(status << 16 | cc << 8 | value);
    //     dev.SendCCMsg(message);
    // }
    
    public override void Send(MidiOutDevice dev, uint channel)
    {
        dev.SendCcMsg((uint) _msgType + channel);
    }

    public void Send(MidiOutDevice dev, uint channel, uint value)
    {
        dev.SendCcMsg((value << 16) + ((uint) _msgType & (uint) MidiCcMsgDefs.Novaluemask) + channel);
    }
    
    public void SendGenerated(MidiOutDevice dev, uint value)
    {
        dev.SendCcMsg(value);
    }

    public uint GenerateMidiCcMsgDef(uint cc, uint value)
    {
        return (value << 16) | (cc << 8) | 0xB0u;
    }
    
    public enum MidiCcMsgDefs : uint
    {
        /* Message definition format:
         *      most significant byte: default value,
         *      least significant byte: status code + channel number (e.g. B0)
         *      middle byte: control code
         */
        AllNotesOff = 0x7BB0u,
        Volume = 0x6407B0u, 
        Pan = 0x3F0AB0u,
        Novaluemask = 0xFFFFu,
        Valuemask = 0xFF0000u,
        CustomCc1 = 0x0101B0u // This is cc 1, value 1 on channel 0
    }
}