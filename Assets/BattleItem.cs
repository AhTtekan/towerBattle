public class BattleItem : Item, IQueueable
{
    public int APCost { get; }
    public TargetTypes TargetType { get; set; }
    /// <summary>
    /// This used for pulling data on gui
    /// </summary>
    public int InventoryCount { get; set; }
}