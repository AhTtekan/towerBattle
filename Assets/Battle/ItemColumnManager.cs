﻿using System.Collections.Generic;

public class ItemColumnManager : ColumnManager
{
    public override IEnumerable<string> GetNextColumnOptions()
    {
        return new[]
        {
            "Item 1",
            "Item 2",
            "Item 3",
            "Item 4",
            "Item 5"
        };
    }
}
