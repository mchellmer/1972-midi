using EightBitSaxLounge.Api.Models;

namespace EightBitSaxLounge.Api.Services.VentrisDualReverbParameters;

public interface IVentrisDualReverbParameterService
{
    void CreateVentrisDualReverbParameter(VentrisDualReverbParameter ventrisDualReverbParameter);
    VentrisDualReverbParameter GetVentrisDualReverbParameter(string id);
    Dictionary<string, VentrisDualReverbParameter> GallAllVentrisDualReverbParameters();
    void UpdateVentrisDualReverbParameter(VentrisDualReverbParameter ventrisDualReverbParameter);
    void DeleteVentrisDualReverbParameter(string id);
}