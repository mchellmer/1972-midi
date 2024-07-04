using System.Collections;
using System.Runtime.InteropServices;

namespace EightBitSaxLounge.Midi.Models.Midi
{
    /* The MidiInProc function is the callback function for handling incoming MIDI messages.
         MidiInProc is a placeholder for the application-supplied function name; MidiInMsgHandler.
         The address of this function can be specified in the callback-address parameter of the midiInOpen function.
      ​   Syntax:
              void CALLBACK MidiInProc(
                HMIDIIN hMidiIn,
                UINT wMsg,                   MIDI message type.
                DWORD_PTR dwInstance,
                DWORD_PTR dwParam1,          The meaning of the dwParam1 and dwParam2 parameters 
                DWORD_PTR dwParam2           is specific to the message type. Typically dwParam1 
                                             contains the MIDI message that was received.
              ); 
         The MIDI message is packed into a double word value as follows:
         ---------DOUBLE WORD-------
         -----WORD----|-----WORD----
         -BYTE-|-BYTE-|-BYTE-|-BYTE-
                Data2  Data1  Status

         So a note on message, which normally reads as 90 3C 7F (9=note on, 0=channel, 3C=note number, 7F=velocity)
         is packed as 00 7F 3C 90 into a DWORD. (This is decimal 8338576.)
    */
    public delegate void MidiInProc(IntPtr handle, UInt32 msgType, UInt32 instance, UInt32 param1, UInt32 param2);

    public abstract class MidiDevice    // 'abstract' means MidiDevice will not be instantiated (only derived classes will)
    {
        [DllImport("winmm.dll")]
        private static extern UInt32 midiInGetNumDevs();

        [DllImport("winmm.dll")]
        private static extern UInt32 midiOutGetNumDevs();

        // in C# Charset.Ansi is used for marshaling (overriding the Charset.Auto CLR default)
        // correspondingly, we use the 'A' version of midiInGetDevCapsA (as opposed to midiInGetDevCapsW)
        // (the CharSet = CharSet.Ansi expression below is redundant)
        [DllImport("winmm.dll", EntryPoint = "midiInGetDevCaps", CharSet = CharSet.Ansi)]
        private static extern MmResult midiInGetDevCapsA(UInt32 devId, ref MidiInCaps devCaps, UInt32 devCapsSize);

        [DllImport("winmm.dll", EntryPoint = "midiOutGetDevCaps")]
        private static extern MmResult midiOutGetDevCapsA(UInt32 devId, ref MidiOutCaps devCaps, UInt32 devCapsSize);

        // when opening a MIDI port the handle variable must be passed by reference, 
        // because it will be assigned a value by the MIDI device
        [DllImport("winmm.dll")]
        protected static extern MmResult midiInOpen(ref IntPtr handle, UInt32 devId, MidiInProc midiInCallback, UInt32 instance, MidiCallbackFlags flags);

        [DllImport("winmm.dll")]
        protected static extern MmResult midiInClose(IntPtr handle);

        // a callback for MIDI 'OUT' will not be implemented
        // in this case NULL should be passed in for the callback argument
        // here, this will be done with IntPtr.Zero
        [DllImport("winmm.dll")]
        protected static extern MmResult midiOutOpen(ref IntPtr handle, UInt32 devId, IntPtr midiOutCallback, UInt32 instance, MidiCallbackFlags flags);

        [DllImport("winmm.dll")]
        protected static extern MmResult midiOutClose(IntPtr handle);

        // MMRESULT midiOutShortMsg(
        //   HMIDIOUT hmo,
        //   DWORD    dwMsg);     this is a 32-bit 'unsigned long' in unmanaged C which corresponds to .NET's System.UInt32
        [DllImport("winmm.dll")]
        protected static extern MmResult midiOutShortMsg(IntPtr handle, UInt32 msg);

        public enum MmResult
        {
            NoError = 0,
            UnspecError = 1,
            BadDeciveId = 2,
            NotEnabled = 3,
            DeviceAlreadyAllocated = 4,
            InvalidHandle = 5,
            NoDriver = 6,
            NoMem = 7,
            NotSupported = 8,
            BadErrNum = 9,
            InvalidFlag = 10,
            InvalidParam = 11,
            HandleBusy = 12,
            InvalidAlias = 13,
            BadDb = 14,
            KeyNotFound = 15,
            ReadError = 16,
            WriteError = 17,
            DeleteError = 18,
            RegistryValueNotFound = 19,
            NoDriverCallback = 20,
            LastError = 20,
            MoreData = 21
        }

        public enum MidiCallbackFlags
        {
            NoCallBack = 0,
            Window = 0x10000,
            Thread = 0x20000,
            Function = 0x30000,
            CallBackEvent = 0x50000,
            MidiIoStatus = 0x20
        }

        public enum MidiMsgTypes
        {
            MmMimOpen = 961,
            MmMimClose = 962,
            MmMimData = 963,
            MmMimLongdata = 964,
            MmMimError = 965,
            MmMimLongerror = 966,
            MmMimMoredata = 972
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MidiInCaps
        {
            public UInt16 manufacturerId;
            public UInt16 productId;
            public UInt32 driverVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] public String deviceName;
            public UInt32 support;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MidiOutCaps
        {
            public UInt16 manufacturerId;
            public UInt16 productId;
            public UInt32 driverVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] public String deviceName;
            public UInt16 wTechnology;
            public UInt16 wSounds;
            public UInt16 wNotes;
            public UInt16 wChannelMask;
            public UInt32 support;
        }

        private static void GetMidiDevices(ArrayList midiInDevices, ArrayList midiOutDevices)
        {
            midiInDevices.Clear();

            UInt32 numDevs = midiInGetNumDevs();
            if (numDevs > 0)
            {
                MidiInCaps inCaps = new MidiInCaps();
                for (UInt32 dev = 0; dev < numDevs; ++dev)
                {
                    MmResult res = midiInGetDevCapsA(dev, ref inCaps, (UInt32)Marshal.SizeOf(inCaps));
                    if (res == MmResult.NoError)
                    {
                        MidiInDevice inDev = new MidiInDevice
                        {
                            DeviceId = dev,
                            DeviceName = inCaps.deviceName,
                            IsRolandFp30Compatible = (inCaps.deviceName.StartsWith(Devices.RolandDevice))
                        };
                        midiInDevices.Add(inDev);
                    }
                }
            }

            midiOutDevices.Clear();

            numDevs = midiOutGetNumDevs();
            if (numDevs > 0)
            {
                MidiOutCaps outCaps = new MidiOutCaps();
                for (UInt32 dev = 0; dev < numDevs; ++dev)
                {
                    MmResult res = midiOutGetDevCapsA(dev, ref outCaps, (UInt32)Marshal.SizeOf(outCaps));
                    if (res == MmResult.NoError)
                    {
                        MidiOutDevice outDev = new MidiOutDevice
                        {
                            DeviceId = dev,
                            DeviceName = outCaps.deviceName,
                            IsRolandFp30Compatible = (outCaps.deviceName.StartsWith(Devices.RolandDevice))
                        };
                        midiOutDevices.Add(outDev);
                    }
                }
            }
        }

        static public void ConfigMidiDevices(ArrayList midiInDevices, ArrayList midiOutDevices)
        {
            GetMidiDevices(midiInDevices, midiOutDevices);

        }

        protected IntPtr Handle;   // a handle to reference the device port in communications
        protected UInt32 DeviceId;
        public string? DeviceName;
        public bool IsRolandFp30Compatible;
        public bool IsOpen; // = false; device is closed initially

        // protected MidiDevice(string deviceName)
        // {
        //     this.DeviceName = deviceName;
        // }
        //
        // protected MidiDevice()
        // {
        //     throw new NotImplementedException();
        // }

        public abstract void Open();    // 'abstract' means derived classes must implement this method
        public abstract void Close();
    }
}
