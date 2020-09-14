using System;
using System.Collections.Generic;
using System.Linq;

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
        //TODO: Test data
        inventoryItems.Add(new BattleItem
        {
            Name = "Potion",
            TargetType = TargetTypes.Ally
        }, 1);
        inventoryItems.Add(new BattleItem
        {
                Name = "Hi Potion",
                TargetType = TargetTypes.Ally
        }, 1);
        inventoryItems.Add(new BattleItem
        {
                Name = "Elixir",
                TargetType = TargetTypes.Ally
        }, 1);
        inventoryItems.Add(new BattleItem
        {
                Name = "Phoenix Down",
                TargetType = TargetTypes.Ally
        }, 1);
        inventoryItems.Add(new BattleItem
        {
                Name = "Potion",
                TargetType = TargetTypes.Ally
        }, 1);
        inventoryItems.Add(new BattleItem
        {
                Name = "Fire Bomb",
                TargetType = TargetTypes.AllEnemies
        }, 1);
        inventoryItems.Add(new BattleItem
        {
                Name = "Restore",
                TargetType = TargetTypes.Ally
        }, 1);
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
        foreach(var item in lockedItems.Keys.ToList())
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
