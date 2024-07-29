using EightBitSaxLounge.Api.Contracts.VentrisDualReverb;
using EightBitSaxLounge.Api.Models;
using EightBitSaxLounge.Api.Services.VentrisDualReverbParameters;

using Microsoft.AspNetCore.Mvc;

namespace EightBitSaxLounge.Api.Controllers;

public class VentrisDualReverbParameterController : ApiController
{
    private readonly IVentrisDualReverbParameterService _ventrisDualReverbParameterService;
    
    [HttpPost]
    public IActionResult CreateVentrisDualReverbParameter(VentrisDualReverbParameterRequest parameterRequest)
    {
        var newParameter = VentrisDualReverbParameter.FromRequest(parameterRequest);
        try
        {
            _ventrisDualReverbParameterService.CreateVentrisDualReverbParameter(newParameter);
            var response = MapVentrisDualReverbResponse(newParameter);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    
    [HttpGet("{id}")]
    public IActionResult GetVentrisDualReverbParameter(string id)
    {
        try
        {
            var ventrisDualReverbParameter = _ventrisDualReverbParameterService.GetVentrisDualReverbParameter(id);
            return Ok(MapVentrisDualReverbResponse(ventrisDualReverbParameter));
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    
    [HttpGet]
    public IActionResult GetVentrisDualReverbParameters()
    {
        try
        {
            var ventrisDualReverbParameters = _ventrisDualReverbParameterService.GallAllVentrisDualReverbParameters();
            var response = new VentrisDualReverbParametersResponse(
                ventrisDualReverbParameters.Select(kvp => MapVentrisDualReverbResponse(kvp.Value)).ToList()
            );
            return Ok(response);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    
    [HttpPut]
    public IActionResult UpdateVentrisDualReverb(VentrisDualReverbParameterRequest parameterRequest)
    {
        var requestedParameter = VentrisDualReverbParameter.FromRequest(parameterRequest);
        try
        {
            _ventrisDualReverbParameterService.UpdateVentrisDualReverbParameter(requestedParameter);
            var response = MapVentrisDualReverbResponse(requestedParameter);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteVentrisDualReverbParameter(VentrisDualReverbParameterRequest parameterRequest)
    {
        var id = $"{parameterRequest.Engine}.{parameterRequest.Name}";
        try
        {
            _ventrisDualReverbParameterService.DeleteVentrisDualReverbParameter(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    
    private static VentrisDualReverbParameterResponse MapVentrisDualReverbResponse(VentrisDualReverbParameter ventrisDualReverbParameter)
    {
        return new VentrisDualReverbParameterResponse(
            ventrisDualReverbParameter.Id,
            ventrisDualReverbParameter.Engine,
            ventrisDualReverbParameter.Name,
            ventrisDualReverbParameter.Value);
    }
}