public class Ability : IQueueable
{
    public virtual int LevelLearned { get; }
    public virtual string Name { get; set; }
    public virtual int APCost { get; }
    public virtual TargetTypes TargetType { get; set; }
}