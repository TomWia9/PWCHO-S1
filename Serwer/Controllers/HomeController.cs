using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Serwer.Models;

namespace Serwer.Controllers;

public class HomeController : Controller
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HomeController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public IActionResult Index()
    {
        var clientIpAddress = GetClientIpAddress();
        var clientTimezone = GetClientTimezone(clientIpAddress);

        ViewData["Title"] = "Server app";
        ViewData["ClientIpAddress"] = clientIpAddress == "::1" ? clientIpAddress + " (localhost)" : clientIpAddress;
        ViewData["ClientTimezone"] = clientTimezone;
        ViewData["ClientDate"] = GetClientDate(clientTimezone);

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    /// <summary>
    ///     Gets client IP address
    /// </summary>
    /// <returns>The ip address</returns>
    private string GetClientIpAddress()
    {
        return _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString()!;
    }

    /// <summary>
    ///     Gets client the client timezone.
    /// </summary>
    /// <param name="clientIpAddress">The client ip address.</param>
    /// <returns>The client date and hour for his timezone.</returns>
    private static string GetClientTimezone(string clientIpAddress)
    {
        //returns local timezone if ip is an localhost ip.
        if (clientIpAddress == "::1")
        {
            return TimeZoneInfo.Local.StandardName;
        }
        
        //gets timezone by ip address from remote api
        var apiUrl = $"https://ipapi.co/{clientIpAddress}/timezone";
        var request = WebRequest.Create(apiUrl);
        var response = request.GetResponse();
        using var dataStream = response.GetResponseStream();
        var reader = new StreamReader(dataStream);
        var timezone = reader.ReadToEnd();

        return timezone;
    }

    /// <summary>
    ///     Gets client the date.
    /// </summary>
    /// <param name="timezone">The client timezone.</param>
    /// <returns>The client date and hour for his timezone.</returns>
    private static string GetClientDate(string timezone)
    {
        //sets the timezone we want to get the current date and time for
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timezone);

        //gets the current date and time for the specified timezone
        var currentDate = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, timeZone);

        //returns the current date and time for the specified timezone
        return currentDate.ToString();
    }
}