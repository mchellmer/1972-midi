namespace EightBitSaxLounge.Midi.Models.Midi;

public class MidiInDevice : MidiDevice
{
    public MidiInProc MidiInCallback = null!;

    public override void Open() 
    {
        MidiInCallback = new MidiInProc(MidiInMsgHandler);

        MmResult result = MmResult.NoError;

        if (!IsOpen)
        {
            result = midiInOpen(ref Handle, DeviceId, MidiInCallback, DeviceId, MidiCallbackFlags.Function | MidiCallbackFlags.MidiIoStatus);

            if (result == MmResult.NoError)
                IsOpen = true;
        }
    }

    public override void Close() 
    {
        MmResult result = MmResult.NoError;

        if (IsOpen)
        {
            result = midiInClose(Handle);

            if (result == MmResult.NoError)
                IsOpen = false;
        }
    }

    public void MidiInMsgHandler(IntPtr handle, UInt32 msgType, UInt32 instance, UInt32 param1, UInt32 param2)
    {
        // the messages received here will inlude the following (among others):
        // MIDI device open : msgType = 961
        //    -"-     close : msgType = 962
        // note on / off : msgType = 963     

        switch ((MidiMsgTypes) msgType) {
            case MidiMsgTypes.MmMimError :
                Console.WriteLine("A MIDI error was received.");
                break;
            case MidiMsgTypes.MmMimOpen :
                Console.WriteLine("The MIDI device is opened.");
                break;
            case MidiMsgTypes.MmMimClose :
                Console.WriteLine("The MIDI device is closed.");
                break;
            case MidiMsgTypes.MmMimData :
                Console.WriteLine("MIDI data were received.");
                break;
            default :
                Console.WriteLine("An unidentified message was received.");
                break;
        }
    }
}