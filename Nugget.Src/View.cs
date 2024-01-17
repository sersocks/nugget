using Logic;
using Models;
using Spectre.Console;

namespace View;

class View
{
    // TODO split this code into simpler chunks
    public static async Task<IEnumerable<string>> Run(string[] args)
    {
        var argsString = string.Join(' ', args);

        if (string.IsNullOrWhiteSpace(argsString))
        {
            AnsiConsole.MarkupLine("[red]Pass at least one argument![/]");
            return [];
        }

        var query = Api.Query(argsString);

        Console.WriteLine();

        var rule = new Rule("[bold purple]Nugget[/]").LeftJustified();
        AnsiConsole.Write(rule);

        var root = await AnsiConsole.Status()
            .Spinner(Spinner.Known.Star)
            .StartAsync("[italic]Loading...[/]", async ctx => await query);

        var packages = root?.Data ?? [];

        if (packages.Count == 0)
        {
            AnsiConsole.MarkupLine($"[ red]No results for [yellow]{argsString}[/]![/]");
            return [];
        }

        var chosen = AnsiConsole.Prompt(
            new MultiSelectionPrompt<Datum>()
            .Title("[bold]Choose some packages[/]")
            .UseConverter(d =>
            {
                var verified = d.Verified ? "  " : "";
                return $"{d.Title}{verified}, 󰇚 {d.TotalDownloads:N0},  {d.Version}";
            })
            .NotRequired()
            .AddChoices(packages)
        );

        if (chosen.Count > 0)
        {
            AnsiConsole.MarkupLine("Installing packages:");
            chosen.ForEach(datum => AnsiConsole.MarkupLine($"- {datum.Title}"));
        }
        else
        {
            AnsiConsole.MarkupLine("Nothing installed!");
            AnsiConsole.MarkupLine("[grey]Make sure you selected the packages you wanted to add with <space>[/]");
        }

        return packages.Select(p => p.PackageId);
    }
}

