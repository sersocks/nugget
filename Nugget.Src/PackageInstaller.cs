using System.Diagnostics;

class PackageInstaller
{
    public static bool ProjectFileFound()
    {
        var filesInDir = Directory.GetFiles(".");

        static bool predicate(string file) =>
            file.Contains(".csproj")
            || file.Contains(".fsproj");

        return filesInDir.Any(predicate);
    }

    public static void InstallPackage(IEnumerable<string> packageNames)
    {
        Console.WriteLine("This is the part where packages are installed lol");

        using var processBase = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                RedirectStandardOutput = false,
                UseShellExecute = true,
                CreateNoWindow = true,
            }
        };

        foreach (var package in packageNames)
        {
            using var installer = Process.Start("dotnet", $"add package {package} --no-restore");
            installer.WaitForExit();
        }
        using var restore = Process.Start("dotnet", "restore");
        restore.WaitForExit();
    }
}
