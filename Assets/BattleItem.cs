public class BattleItem : Item, IQueueable
{
    public string Name { get; set; }
    public int APCost { get; }
    public TargetTypes TargetType { get; set; }
}