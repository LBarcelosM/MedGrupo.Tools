using System.Text;

var successText = @"
░█▀▀░█░█░█▀▀░█▀▀░█▀▀░█▀▀░█▀█
░▀▀█░█░█░█░░░█▀▀░▀▀█░▀▀█░█░█
░▀▀▀░▀▀▀░▀▀▀░▀▀▀░▀▀▀░▀▀▀░▀▀▀
";
var errorText = @"
░█▀▀░█▀▄░█▀▄░█▀█
░█▀▀░█▀▄░█▀▄░█░█
░▀▀▀░▀░▀░▀░▀░▀▀▀
";



var localAppFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

var localAppDirectory = new DirectoryInfo(Path.Combine(localAppFolder, "medsoft-pro-updater"));
var appDataDirectory = new DirectoryInfo(Path.Combine(appDataFolder, "medsoft-pro"));


var localAppDeleted = false;
var appDataDeleted = false;

if (localAppDirectory.Exists)
{
    localAppDirectory.Delete(true);
    localAppDeleted = true;
}

if (appDataDirectory.Exists)
{
    appDataDirectory.Delete(true);
    appDataDeleted = true;
}

if(localAppDeleted || appDataDeleted)
{
    var completeSuccessText = new StringBuilder();
    completeSuccessText.AppendLine(successText);
    completeSuccessText.AppendLine("Diretório(s) excluído(s):");
    if(localAppDeleted)
    {
        completeSuccessText.AppendLine(localAppDirectory.FullName);
    }
    if (appDataDeleted)
    {
        completeSuccessText.AppendLine(appDataDirectory.FullName);
    }
    Console.WriteLine(completeSuccessText);
}
else
{
    Console.WriteLine(errorText);
    Console.WriteLine("Diretórios não encontrados.");
}

Console.ReadLine();