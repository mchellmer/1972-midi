using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEffects;
using EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

namespace EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEngines;

public class VentrisReverbEngine
{
    public int MidiControlChangeId { get; set; }
    public List<VentrisReverbEffect>? VentrisReverbEffects { get; set; }
    public List <VentrisReverbSetting> VentrisReverbSettings { get; set; }

    public VentrisReverbEffect? GetEffectByName(string effectName)
    {
        return VentrisReverbEffects!.FirstOrDefault(effect => effect.MidiControlChangeValueName!.Equals(effectName, StringComparison.OrdinalIgnoreCase));
    }
    public VentrisReverbEngine(int midiControlChangeId)
    {
        MidiControlChangeId = midiControlChangeId;
        var assembly = Assembly.GetExecutingAssembly();
        var effectTypes = assembly.GetTypes()
            .Where(t => t.IsClass
                        && !t.IsAbstract
                        && t.Namespace == "EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEffects"
                        && t.IsSubclassOf(typeof(VentrisReverbEffect)))
            .ToList();

        VentrisReverbEffects = effectTypes.Select(t => (VentrisReverbEffect)Activator.CreateInstance(t)!).ToList();

        // Load VentrisReverbSettings and adjust MidiControlChangeId to base on engine cc id
        var settingTypes = assembly.GetTypes()
            .Where(t => t.IsClass
                        && !t.IsAbstract
                        && t.Namespace == "EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings"
                        && t.IsSubclassOf(typeof(VentrisReverbSetting)))
            .ToList();

        VentrisReverbSettings = settingTypes.Select(t =>
        {
            var setting = (VentrisReverbSetting)Activator.CreateInstance(t)!;
            setting.MidiControlChangeId += (MidiControlChangeId - 1);
            return setting;
        }).ToList();

        // Add effect specific engine parameters x5 to settings
        for (int i = 1; i < 5; i++)
        {
            VentrisReverbSettings.Add(new VentrisReverbSetting() 
                { 
                    MidiControlChangeName = $"Engine Param {i}", 
                    MidiControlChangeId = MidiControlChangeId + i + 13, //add Engine Param CCid section offset
                    MidiControlChangeDescription = $"Sets Engine Param {i} (engine dependent)"
                });    
        }
    }
}