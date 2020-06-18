using System.Collections.Generic;
using UnityEngine;

public abstract class ColumnManager : MonoBehaviour
{
    public Unit AssociatedTarget { get; set; }

    public IQueueable AssociatedAction { get; set; }

    public abstract IEnumerable<IQueueable> GetNextColumnOptions();
}
