//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/QueenofMonsters/CelestialRealmATheftofLight/CoreCelestialRealm.cs
using RBot;

public class CompleteLostRuinsWar
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreStory Story = new CoreStory();
    public CoreCelestialRealm Celestial => new CoreCelestialRealm();
    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        Celestial.LostRuinsWar();

        Core.SetOptions(false);
    }
}