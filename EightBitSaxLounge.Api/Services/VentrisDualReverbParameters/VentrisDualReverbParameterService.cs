using EightBitSaxLounge.Api.Models;
using EightBitSaxLounge.Api.Services.VentrisDualReverbParameters;

namespace EightBitSaxLounge.Api.Services;

public class VentrisDualReverbParameterService : IVentrisDualReverbParameterService
{
    private static readonly Dictionary<string, VentrisDualReverbParameter> VentrisDualReverbParameters = new();
    
    public void CreateVentrisDualReverbParameter(VentrisDualReverbParameter ventrisDualReverbParameter)
    {
        VentrisDualReverbParameters.Add(ventrisDualReverbParameter.Id, ventrisDualReverbParameter);
    }
    
    public VentrisDualReverbParameter GetVentrisDualReverbParameter(string id)
    {
        return VentrisDualReverbParameters[id];
    }
    
    public Dictionary<string, VentrisDualReverbParameter> GallAllVentrisDualReverbParameters()
    {
        return VentrisDualReverbParameters;
    }

    public void UpdateVentrisDualReverbParameter(VentrisDualReverbParameter ventrisDualReverbParameter)
    {
        VentrisDualReverbParameters[ventrisDualReverbParameter.Id] = ventrisDualReverbParameter;
    }

    public void DeleteVentrisDualReverbParameter(string id)
    {
        VentrisDualReverbParameters.Remove(id);
    }
}