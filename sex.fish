dotnet tool uninstall -g nugget.src
dotnet pack
dotnet tool install --global --add-source ./nupkg nugget.src
