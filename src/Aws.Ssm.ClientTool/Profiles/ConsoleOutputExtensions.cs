using ConsoleTables;

namespace Aws.Ssm.ClientTool.Profiles;

public static class ConsoleOutputExtensions
{
    public static void PrintProfileSettings(this ProfileDo profileDo)
    {
        if (profileDo == null)
        {
            return;
        }
        
        var table = new ConsoleTable("setting-name", "setting-value");

        table.AddRow(nameof(profileDo.EnvironmentVariablePrefix), profileDo.EnvironmentVariablePrefix);

        table.AddRow(nameof(profileDo.SsmPaths) + ".Count()", profileDo.SsmPaths?.Count ?? 0);
        if (profileDo.SsmPaths != null)
        {
            var index = 0;
            foreach (var ssmPath in profileDo.SsmPaths.OrderBy(x => x))
            {
                table.AddRow(
                    $"{nameof(profileDo.SsmPaths)}[{index++}]", 
                    ssmPath);
            }
        }

        table.Write(Format.Minimal);    
    }
}