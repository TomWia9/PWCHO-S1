using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
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
        //Console.WriteLine("Ip address: " + clientIpAddress);

        var clientTimezone = GetClientTimezone(clientIpAddress);
        //Console.WriteLine("Timezone: " + clientTimezone);
        
        var clientDate = GetClientDate(clientTimezone);
        //Console.WriteLine("Date: " + clientDate);

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
    private static string GetClientIpAddress()
    {
        var name = Dns.GetHostName();
        var ip = Dns.GetHostEntry(name).AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
        return ip.ToString();
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
        try
        {
            //sets the timezone we want to get the current date and time for
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timezone);

            //gets the current date and time for the specified timezone
            var currentDate = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, timeZone);

            //returns the current date and time for the specified timezone
            return currentDate.ToString();
        }
        catch (Exception e)
        {
            return "The current date cannot be determined from an undefined time zone. The client's IP address is probably private.";
        }
    }
}