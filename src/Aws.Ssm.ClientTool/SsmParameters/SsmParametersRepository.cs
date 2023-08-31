using Microsoft.Extensions.Configuration;

namespace Aws.Ssm.ClientTool.SsmParameters;

public class SsmParametersRepository
{
    public IDictionary<string, string> GetDictionaryBy(ISet<string> paths)
    {
        if (paths.Any() == false)
        {
            return new Dictionary<string, string>();
        }

        var configuration = LoadSystemParameters(paths);
        
        var result = new SortedDictionary<string, string>();
        configuration.Bind(result);

        return result;
    }

    private IConfiguration LoadSystemParameters(IEnumerable<string> paths)
    {
        var configurationBuilder = new ConfigurationBuilder();

        foreach (var path in paths)
        {
            configurationBuilder.AddSystemsManager(configurationSource =>
            {
                configurationSource.Path = path;
                //configurationSource.ReloadAfter = TimeSpan.FromMinutes(15);
                configurationSource.ParameterProcessor = new SsmParameterProcessor();
            });
        }

        return configurationBuilder.Build();
    }
}