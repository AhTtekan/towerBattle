using System;
using System.Collections.Generic;

public class ItemColumnManager : ColumnManager
{
    public override IEnumerable<IQueueable> GetNextColumnOptions()
    {
        //TODO: Test data
        return new List<BattleItem>()
        {
            new BattleItem
            {
                Name = "Potion"
            },
            new BattleItem
            {
                Name = "Hi Potion"
            },
            new BattleItem
            {
                Name = "Elixir"
            },
            new BattleItem
            {
                Name = "Phoenix Down"
            },
            new BattleItem
            {
                Name = "Potion"
            },
            new BattleItem
            {
                Name = "Fire Bomb"
            },
            new BattleItem
            {
                Name = "Restore"
            },
        };
    }
}
