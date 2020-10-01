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
    private List<Item> inventoryItems = new List<Item>();
    private List<Item> lockedItems = new List<Item>();

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
        i2.Name = "Hi Potion";
        i2.TargetType = TargetTypes.Ally;
        result.Add(i2);

        var i3 = ScriptableObject.CreateInstance<BattleItem>();
        i3.Name = "Elixir";
        i3.TargetType = TargetTypes.Ally;
        result.Add(i3);

        var i4 = ScriptableObject.CreateInstance<BattleItem>();
        i4.Name = "Phoenix Down";
        i4.TargetType = TargetTypes.Ally;
        result.Add(i4);

        var i5 = ScriptableObject.CreateInstance<BattleItem>();
        i5.Name = "Potion";
        i5.TargetType = TargetTypes.Ally;
        result.Add(i5);

        var i6 = ScriptableObject.CreateInstance<BattleItem>();
        i6.Name = "Fire Bomb";
        i6.TargetType = TargetTypes.AllEnemies;
        result.Add(i6);

        var i7 = ScriptableObject.CreateInstance<BattleItem>();
        i7.Name = "Restore";
        i7.TargetType = TargetTypes.Ally;
        result.Add(i7);

        return result;
    }

    public void AddItem(Item item)
    {
        inventoryItems.Add(item);
    }

    public Dictionary<Item, int> GetAllItems()
    {
        Dictionary<Item, int> result = new Dictionary<Item, int>();

        foreach (var item in inventoryItems.Distinct())
        {
            result.Add(item, inventoryItems.Count(x => x.Equals(item)));
        }

        return result;
    }

    public Dictionary<BattleItem, int> GetBattleItems()
    {
        Dictionary<BattleItem, int> result = new Dictionary<BattleItem, int>();

        foreach (BattleItem item in inventoryItems.Where(x => x is BattleItem).Distinct())
        {
            result.Add(item, inventoryItems.Count(x => x.Equals(item)));
        }

        return result;
    }

    public Dictionary<Item, int> GetLockedItems()
    {
        Dictionary<Item, int> result = new Dictionary<Item, int>();

        foreach (var item in lockedItems.Distinct())
        {
            result.Add(item, lockedItems.Count(x => x.Equals(item)));
        }

        return result;
    }

    public void LockItem(Item item)
    {
        RemoveItem(item);
        addToLockedItems(item);
    }

    public void RemoveItem(Item item)
    {
        inventoryItems.Remove(item);
    }

    public void RemoveLockedItems()
    {
        lockedItems.Clear();
    }

    public void UnlockAllItems()
    {
        foreach (var item in lockedItems)
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
        lockedItems.Add(item);

        RemoveItem(item);
    }

    private void removeFromLockedItems(Item item)
    {
        if (!lockedItems.Contains(item))
            throw new IndexOutOfRangeException($"{item.Name} not currently locked.");

        lockedItems.Remove(item);

        AddItem(item);
    }
}
