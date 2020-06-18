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
            Name = "Lightning",
            TargetType = TargetTypes.Enemy
        },
        new Ability
        {
            Name = "Heal",
            TargetType = TargetTypes.Ally
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