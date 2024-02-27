using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

var app = WebApplication.Create(args);
app.UseRouting();

string krypteradText = "";

app.MapPost("/kryptera", async context =>
{
    using var reader = new StreamReader(context.Request.Body);
    var vanligText = await reader.ReadToEndAsync();
    krypteradText = KrypteraMedCaesarChiffer(vanligText, 3);
    await context.Response.WriteAsync("Krypterad text med Caesar-chiffer: " + krypteradText);
});

app.MapPost("/dekryptera", async context =>
{
    if (string.IsNullOrEmpty(krypteradText))
    {
        context.Response.StatusCode = 400; 
        await context.Response.WriteAsync("Ingen krypterad text tillgänglig.");
        return;
    }

    string dekrypteradText = DekrypteraMedCaesarChiffer(krypteradText, 3);
    await context.Response.WriteAsync("Dekrypterad text: " + dekrypteradText);
});

app.Run();

static string KrypteraMedCaesarChiffer(string text, int skift)
{
    string krypteradText = "";
    foreach (char tecken in text)
    {
        if (char.IsLetter(tecken))
        {
            char förskjutetTecken = (char)(tecken + skift);
            if (char.IsLower(tecken))
            {
                if (tecken >= 'a' && tecken <= 'z')
                {
                    förskjutetTecken = (char)(((tecken - 'a') + skift) % 29 + 'a');
                }
                else if (tecken == 'å')
                {
                    förskjutetTecken = 'a';
                }
                else if (tecken == 'ä')
                {
                    förskjutetTecken = 'z';
                }
                else if (tecken == 'ö')
                {
                    förskjutetTecken = 'ä';
                }
            }
            else if (char.IsUpper(tecken))
            {
                if (tecken >= 'A' && tecken <= 'Z')
                {
                    förskjutetTecken = (char)(((tecken - 'A') + skift) % 29 + 'A');
                }
                else if (tecken == 'Å')
                {
                    förskjutetTecken = 'A';
                }
                else if (tecken == 'Ä')
                {
                    förskjutetTecken = 'Z';
                }
                else if (tecken == 'Ö')
                {
                    förskjutetTecken = 'Ä';
                }
            }
            krypteradText += förskjutetTecken;
        }
        else if (char.IsDigit(tecken))
        {
            char förskjutetTecken = (char)(tecken + skift);
            if (förskjutetTecken > '9')
            {
                förskjutetTecken = (char)(förskjutetTecken - 10);
            }
            else if (förskjutetTecken < '0')
            {
                förskjutetTecken = (char)(förskjutetTecken + 10);
            }
            krypteradText += förskjutetTecken;
        }
        else
        {
            krypteradText += tecken;
        }
    }
    return krypteradText;
}

static string DekrypteraMedCaesarChiffer(string text, int skift)
{
    return KrypteraMedCaesarChiffer(text, -skift);
}
