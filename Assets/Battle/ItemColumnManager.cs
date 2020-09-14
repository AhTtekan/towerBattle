using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemColumnManager : ColumnManager
{
    public override IEnumerable<IQueueable> GetNextColumnOptions()
    {
        var inventory = GameObject.FindObjectOfType<CharacterManager>().Inventory;

        var items = inventory.GetBattleItems().Select(x => x.Key);

        foreach (var item in items)
            item.InventoryCount = inventory.GetBattleItems()[item];

        return items;
    }
}
