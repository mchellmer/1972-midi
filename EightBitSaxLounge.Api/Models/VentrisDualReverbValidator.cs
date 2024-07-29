namespace EightBitSaxLounge.Api.Models;

using System.Linq;
using System.Reflection;
using EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbEffects;
using EightBitSaxLounge.Midi.Models.VentrisDualReverb.ReverbSettings;

public static class ReverbParameterValidator
{
    public static bool IsValidName(string name)
    {
        var effectBaseType = typeof(VentrisReverbEffect);
        var settingBaseType = typeof(VentrisReverbSetting);
        var assembly = Assembly.GetAssembly(effectBaseType);

        var validNames = assembly!.GetTypes()
            .Where(t => (
                t.IsSubclassOf(effectBaseType) ||
                t.IsSubclassOf(settingBaseType)) && 
                        !t.IsAbstract)
            .Select(t => t.Name)
            .ToList();

        return validNames.Contains(name);
    }
}