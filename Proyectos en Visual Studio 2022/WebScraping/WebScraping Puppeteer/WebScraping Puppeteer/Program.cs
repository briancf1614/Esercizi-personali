using PuppeteerSharp;





string url = "https://listado.mercadolibre.com.mx/cervezas#D[A:cervezas]";
string edge = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";

using var browserFetcher = new BrowserFetcher();
await browserFetcher.DownloadAsync();

await using var browser = await Puppeteer.LaunchAsync(
    new LaunchOptions
    {
        Headless = true,
        ExecutablePath = edge

    });

await using var page = await browser.NewPageAsync();

await page.GoToAsync(url);


List<string> titles = new List<string>();

var result = await page.EvaluateFunctionAsync("()=>{" +
    "const a = document.querySelectorAll('.ui-search-item__title');" +
    "const res = [];" +
    "for(let i=0; i<a.length; i++)" +
    "   res.push(a[i].innerHTML);" +
    "return res;" +
    "}");

foreach (var e in result)
    Console.WriteLine(e);