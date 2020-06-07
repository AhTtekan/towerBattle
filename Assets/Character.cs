using System.Collections.Generic;
using System.Linq;

public class Character : Unit
{
    public int Level { get; set; }

    public IEnumerable<Ability> Abilities { get; set; }

    public IEnumerable<Ability> LearnedAbilities
    {
        get
        {
            return Abilities.Where(x => x.LevelLearned <= Level);
        }
    }
}