using System.Text;

namespace Aws.Ssm.ClientTool.EnvironmentVariables.Rules;

public static class EnvironmentVariablesScriptTextBuilder
{
    public static string Build(IDictionary<string, string> environmentVariables)
    {
        var stringBuilder = new StringBuilder();

        foreach (var envVar in environmentVariables)
        {
            stringBuilder.Append("export ");

            stringBuilder.Append(envVar.Key);
            stringBuilder.Append('=');

            stringBuilder.Append('"');
            stringBuilder.Append(EscapeValue(envVar.Value));
            stringBuilder.Append('"');
            
            stringBuilder.AppendLine();
        }

        return stringBuilder.ToString();
    }

    private static string EscapeValue(string environmentValue)
    {
        var stringBuilder = new StringBuilder();

        foreach (var c in environmentValue)
        {
            var newStr = c switch
            {
                '"' => "\\\"",
                '\\' => "\\\\",
                '$' => "\\$",
                '`' => "\\`",
                _ => c.ToString(),
            };

            stringBuilder.Append(newStr);
        }
            
        return stringBuilder.ToString();
    }
}