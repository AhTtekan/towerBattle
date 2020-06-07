using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilityColumnManager : ColumnManager
{
    public override IEnumerable<IQueueable> GetNextColumnOptions()
    {
        var abilities = GameObject.FindObjectOfType<CharacterManager>().SelectedCharacter.LearnedAbilities;

        return abilities.Select(x => x as IQueueable);
    }
}
