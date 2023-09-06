namespace Aws.Ssm.ClientTool.Profiles;

public class ProfileConfig
{
    public HashSet<string> SsmPaths { get; set; } = new();

    public string EnvironmentVariablePrefix { get; set; } = "SSM_";

    public bool IsValid => SsmPaths?.Any() == true;

    public ProfileConfig Clone() => (ProfileConfig) this.MemberwiseClone();
}