public interface IQueueable
{
    string Name { get; set; }

    int APCost { get; }

    TargetTypes TargetType { get; set; }
}