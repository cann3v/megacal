using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace megacal.Controllers;

[Route("")]
public class HomeController: Controller
{
    [HttpGet("")]
    public async Task<IActionResult> Index([FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return View();
        
        Home getParams = new Home
        {
            FileName = name,
        };

        Process process = new Process();
        process.StartInfo.FileName = "/bin/bash";
        process.StartInfo.Arguments = $"-c \"cat {name}\"";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();
        await process.WaitForExitAsync();
        if (process.ExitCode != 0)
            getParams.Result = "Command execution error";
        else
            getParams.Result = await process.StandardOutput.ReadToEndAsync();
        
        return View(getParams);
    }
}
