using EightBitSaxLounge.Api.Contracts.VentrisDualReverb;

namespace EightBitSaxLounge.Api.Models;

public class VentrisDualReverbParameter
{
    public string Id { get; }
    public string Engine { get; }
    public string Name { get; }
    public string Value { get; }

    public static VentrisDualReverbParameter FromNameAndValue(string name, string value)
    {
        if (!ReverbParameterValidator.IsValidName(name))
        {
            throw new ArgumentException($"Invalid name: {name}.", nameof(name));
        }
        return new VentrisDualReverbParameter(name, value);
    }

    public static VentrisDualReverbParameter FromRequest(VentrisDualReverbParameterRequest request)
    {
        if (!ReverbParameterValidator.IsValidName(request.Name))
        {
            throw new ArgumentException($"Invalid name: {request.Name}.", nameof(request.Name));
        }
        return new VentrisDualReverbParameter(request.Name, request.Value, request.Engine);
    }

    private VentrisDualReverbParameter(string name, string value, string engine = "a")
    {
        Id = $"{engine}.{name}";
        Engine = string.IsNullOrEmpty(engine) ? "a" : engine;
        Name = name;
        Value = value;
    }
}