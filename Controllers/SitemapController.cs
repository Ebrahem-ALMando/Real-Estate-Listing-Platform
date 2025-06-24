using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml.Linq;
using RealEstateMVC.Data;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly string baseUrl = "http://localhost:5042";

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("/sitemap.xml")]
    public IActionResult Sitemap()
    {
        var urls = new List<string>
        {
            "/", "/about", "/services", "/properties", "/blog", "/contact", "/Booking/MyBookings"
        };

        var propertyUrls = _context.Properties
            .Select(p => $"/Properties/Details/{p.Id}")
            .ToList();

        urls.AddRange(propertyUrls);

        XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";

        var sitemap = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement(ns + "urlset",
                urls.Select(url => new XElement(ns + "url",
                    new XElement(ns + "loc", baseUrl + url),
                    new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd")),
                    new XElement(ns + "changefreq", "weekly"),
                    new XElement(ns + "priority", url == "/" ? "1.0" : "0.8")
                ))
            )
        );

        var xml = sitemap.ToString();
        return Content(xml, "application/xml", Encoding.UTF8);
    }
}
