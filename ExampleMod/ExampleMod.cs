using Beebo;
using Beebo.GameContent.Components;

namespace ExampleMod;

// Mod dependencies have 3 kinds: Required, Optional, and Incompatible
// How a mod is determined to meet the condition, is determined by the specified version range
// Check out https://jubianchi.github.io/semver-check/#/constraint/^1.0 for testing out semantic version range schemes
// You can use as many ModDependency attributes as you need, like this:
[ModDependency("coremods", ModDependency.DependencyKind.Required, "^1.0")]
// (note: coremods is builtin so it will always be loaded anyway. this is just an example)

// You MUST add the ModInfo attribute to your mod class, or else the entire mod fails to load
[ModInfo(MOD_GUID, MOD_NAME, MOD_VERSION)]
public class ExampleMod : Mod
{
    public const string MOD_GUID = "bscit.example";
    public const string MOD_NAME = "Example Mod";
    public const string MOD_VERSION = "1.0.0";

    public override void OnBeforeRun()
    {
        Logger.LogInfo("Hello World!");

        On.Beebo.GameContent.Components.Player.OnCreated += Player_OnCreated;
    }

    private void Player_OnCreated(On.Beebo.GameContent.Components.Player.orig_OnCreated orig, Player self)
    {
        orig(self);

        Logger.LogInfo("Player created!");
    }
}
