using System.Collections.Generic;
using System.Linq;

//TODO: make this abstract after testing
public class Character : Unit
{
    public int Level { get; set; }

    //TODO: Test Data
    public IEnumerable<Ability> Abilities { get; set; }
    = new List<Ability>() {
        new Ability
        {
            Name = "Lightning"
        },
        new Ability
        {
            Name = "Heal"
        }
    };

    public IEnumerable<Ability> LearnedAbilities
    {
        get
        {
            return Abilities.Where(x => x.LevelLearned <= Level);
        }
    }
}