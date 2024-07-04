// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Threading;

using Autofac;

using EightBitSaxLounge.Midi.Models;
using EightBitSaxLounge.Midi.Models.Midi;
using EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEffects;
using EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEngines;

ArrayList midiInDevices = new ArrayList();
ArrayList midiOutDevices = new ArrayList();

MidiDevice.ConfigMidiDevices(midiInDevices, midiOutDevices);

VentrisReverbEngine ventrisReverbEngineA = new VentrisReverbEngine(1);
VentrisReverbEngine ventrisReverbEngineB = new VentrisReverbEngine(25);

var roomEffectB = ventrisReverbEngineB.GetEffectByName("room");
if (roomEffectB != null)
{
    Console.WriteLine("Properties of roomEffectA:");
    foreach (var prop in roomEffectB.GetType().GetProperties())
    {
        Console.WriteLine($"{prop.Name}: {prop.GetValue(roomEffectB)}");
    }
}
else
{
    Console.WriteLine("roomEffectB is null.");
}
Console.WriteLine($"Engine A CC ID: {ventrisReverbEngineB.MidiControlChangeId}");

var ccMessage = new MidiCcMessage(MidiCcMessage.MidiCcMsgDefs.CustomCc1);
var msg = ccMessage.GenerateMidiCcMsgDef((uint)ventrisReverbEngineB.MidiControlChangeId, (uint)roomEffectB!.MidiControlChangeValueId);

Console.WriteLine("MIDI 'IN' devices:");
foreach (MidiInDevice dev in midiInDevices) {
    Console.WriteLine(dev.DeviceName);
    if (dev.DeviceName == Devices.VentrisReverb) {
        Console.WriteLine("Opening 'IN' device " + dev.DeviceName + "...");
        dev.Open();
        Thread.Sleep(5000); // pause for 5 sec.
        Console.WriteLine("Closing 'IN' device " + dev.DeviceName + "...");
        dev.Close();
    }
}

Console.WriteLine("MIDI 'OUT' devices:");
foreach (MidiOutDevice dev in midiOutDevices) { 
    Console.WriteLine(dev.DeviceName);
    Console.WriteLine(Devices.VentrisReverb == dev.DeviceName);
    if (dev.DeviceName!.Trim() == Devices.VentrisReverb) {
        Console.WriteLine("Opening 'OUT' device " + dev.DeviceName + "...");
        dev.Open();
        
        ccMessage.SendGenerated(dev, msg);
        
        // Console.WriteLine("Playing a couple of notes on channel 1 ...");
        // MidiMusicalNote middleC = new MidiMusicalNote();
        // middleC.BeginPlay(dev);
        // Thread.Sleep(1000);
        // middleC.EndPlay(dev);
        // MidiMusicalNote noteA = new (0, 69, 77);
        // noteA.BeginPlay(dev);
        // Thread.Sleep(3000);
        // noteA.EndPlay(dev);

        Thread.Sleep(5000); // pause for 5 sec.
        Console.WriteLine("Closing 'OUT' device " + dev.DeviceName + "...");
        dev.Close();
    }
}

Console.WriteLine("We are done.");
Console.ReadLine();
