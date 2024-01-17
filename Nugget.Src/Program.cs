using Spectre.Console;

if (!PackageInstaller.ProjectFileFound())
{
    AnsiConsole.MarkupLine("[red]Project file not found![/]");
    return 1;
}

var packages = await View.View.Run(args);

PackageInstaller.InstallPackage(packages);

return 0;
