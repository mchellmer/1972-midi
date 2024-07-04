namespace EightBitSaxLounge.Midi.Models.Midi;

public class MidiOutDevice : MidiDevice
{
    public override void Open() 
    {
        MmResult result = MmResult.NoError;

        if (!IsOpen)
        {
            result = midiOutOpen(ref Handle, DeviceId, IntPtr.Zero, 0, MidiCallbackFlags.NoCallBack);

            if (result == MmResult.NoError)
                IsOpen = true;
        }
    }

    public override void Close() 
    {
        MmResult result = MmResult.NoError;

        if (IsOpen)
        {
            result = midiOutClose(Handle);

            if (result == MmResult.NoError)
                IsOpen = false;
        }
    }

    public void SendCcMsg(UInt32 msg)
    {
        if (IsOpen)
            midiOutShortMsg(Handle, msg);
    }
}