using System.Collections.Generic;

public class GeneralColumnManager : ColumnManager
{
    public override IEnumerable<string> GetNextColumnOptions()
    {
        return new[]
        {
            "Column 3 Content 1",
            "Column 3 Content 2",
        };
    }
}
