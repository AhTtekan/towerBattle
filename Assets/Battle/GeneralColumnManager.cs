using System;
using System.Collections.Generic;

/// <summary>
/// Used for Column 3 Content generation
/// Column 3 content is Target Selection
/// Content will be based on column 2 selection (attack, defend, item, ability)
/// </summary>
public class GeneralColumnManager : ColumnManager
{
    public override IEnumerable<IQueueable> GetNextColumnOptions()
    {
        throw new NotImplementedException();
    }
}
