//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
using Skua.Core.Interfaces;

public class SweatBirthdayTreatsRewards
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        QuestFarming();

        Core.SetOptions(false);
    }

    public void QuestFarming()
    {
        List<Skua.Core.Models.Items.ItemBase> RewardOptions = Core.EnsureLoad(8906).Rewards;
        List<string> RewardsList = new List<string>();
        foreach (Skua.Core.Models.Items.ItemBase Item in RewardOptions)
            RewardsList.Add(Item.Name);

        string[] Rewards = RewardsList.ToArray();
        Bot.Drops.Add(Rewards);

        if (Core.CheckInventory(Rewards, toInv: false))
            return;

        int i = 0;

        while (!Bot.ShouldExit && !Core.CheckInventory(Rewards, toInv: false))
        {
            //Sweet Birthday Treats 8906
            Core.EnsureAccept(8906);

            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("birthday", "Twilly Pinata", "Pinata Candy", 100, isTemp: false, log: false);

            Core.EnsureComplete(8906);
            i++;

            if (i % 5 == 0)
            {
                Core.JumpWait();
                Core.ToBank(Rewards);
            }
        }
        Core.ToBank(Rewards);
    }
}
