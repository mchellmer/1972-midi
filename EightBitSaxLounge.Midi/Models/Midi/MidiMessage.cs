namespace EightBitSaxLounge.Midi.Models.Midi;
abstract class MidiMessage
{
/*
        The MIDI message is packed into a double word value as follows:
        ---------DOUBLE WORD-------
        -----WORD----|-----WORD----
        -BYTE-|-BYTE-|-BYTE-|-BYTE-
                Data2  Data1  Status

        So a note-on message, which normally reads as 90 3C 7F (9=note on, 0=channel, 3C=note number, 7F=velocity)
        is packed as 00 7F 3C 90 into a DWORD. (This is decimal 8338576.)
*/
    public abstract void Send(MidiOutDevice dev, uint channel);
}