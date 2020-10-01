using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IInventory
{
    Dictionary<BattleItem, int> GetBattleItems();

    Dictionary<Item, int> GetAllItems();

    Dictionary<Item, int> GetLockedItems();

    void UnlockAllItems();

    void UnlockItem(Item item);

    void RemoveLockedItems();

    void LockItem(Item item);

    void AddItem(Item item);

    void RemoveItem(Item item);
}

public class Inventory : IInventory
{
    private Dictionary<Item, int> inventoryItems = new Dictionary<Item, int>();
    private Dictionary<Item, int> lockedItems = new Dictionary<Item, int>();

    public Inventory()
    {
        var testItems = GetTestData();
        foreach (var testItem in testItems)
        {
            AddItem(testItem);
        }
    }

    public IEnumerable<Item> GetTestData()
    {
        List<Item> result = new List<Item>();
        //TODO: Test data

        var i1 = ScriptableObject.CreateInstance<BattleItem>();
        i1.Name = "Potion";
        i1.TargetType = TargetTypes.Ally;
        result.Add(i1);

        var i2 = ScriptableObject.CreateInstance<BattleItem>();
        i1.Name = "Hi Potion";
        i1.TargetType = TargetTypes.Ally;
        result.Add(i2);

        var i3 = ScriptableObject.CreateInstance<BattleItem>();
        i1.Name = "Elixir";
        i1.TargetType = TargetTypes.Ally;
        result.Add(i3);

        var i4 = ScriptableObject.CreateInstance<BattleItem>();
        i1.Name = "Phoenix Down";
        i1.TargetType = TargetTypes.Ally;
        result.Add(i4);

        var i5 = ScriptableObject.CreateInstance<BattleItem>();
        i1.Name = "Potion";
        i1.TargetType = TargetTypes.Ally;
        result.Add(i5);

        var i6 = ScriptableObject.CreateInstance<BattleItem>();
        i1.Name = "Fire Bomb";
        i1.TargetType = TargetTypes.AllEnemies;
        result.Add(i6);

        var i7 = ScriptableObject.CreateInstance<BattleItem>();
        i1.Name = "Restore";
        i1.TargetType = TargetTypes.Ally;
        result.Add(i7);

        return result;
    }

    public void AddItem(Item item)
    {
        if (inventoryItems.ContainsKey(item))
            inventoryItems[item]++;
        else
            inventoryItems.Add(item, 1);
    }

    public Dictionary<Item, int> GetAllItems()
    {
        return inventoryItems;
    }

    public Dictionary<BattleItem, int> GetBattleItems()
    {
        return inventoryItems.Where(x => x.Key is BattleItem)
            .ToDictionary(x => x.Key as BattleItem, x => x.Value);
    }

    public Dictionary<Item, int> GetLockedItems()
    {
        return lockedItems;
    }

    public void LockItem(Item item)
    {
        RemoveItem(item);
        addToLockedItems(item);
    }

    public void RemoveItem(Item item)
    {
        if (!inventoryItems.ContainsKey(item) || inventoryItems[item] == 0)
            throw new IndexOutOfRangeException($"Inventory does not contain item {item.Name}");
        inventoryItems[item]--;
        if (inventoryItems[item] == 0)
            inventoryItems.Remove(item);
    }

    public void RemoveLockedItems()
    {
        lockedItems.Clear();
    }

    public void UnlockAllItems()
    {
        foreach (var item in lockedItems.Keys.ToList())
        {
            UnlockItem(item);
        }
    }

    public void UnlockItem(Item item)
    {
        removeFromLockedItems(item);
        AddItem(item);
    }

    private void addToLockedItems(Item item)
    {
        if (lockedItems.ContainsKey(item))
            lockedItems[item]++;
        else
            lockedItems.Add(item, 1);

        RemoveItem(item);
    }

    private void removeFromLockedItems(Item item)
    {
        if (!lockedItems.ContainsKey(item) || lockedItems[item] == 0)
            throw new IndexOutOfRangeException($"{item.Name} not currently locked.");

        lockedItems[item]--;
        if (lockedItems[item] == 0)
            lockedItems.Remove(item);

        AddItem(item);
    }
}
