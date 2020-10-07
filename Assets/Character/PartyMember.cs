using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Character", order = 1)]
public class PartyMember : Character
{
    public int Level;

    public int Experience;

    public Sprite characterSprite;

    public override TargetTypes targetType => TargetTypes.Ally;

    public IEnumerable<Ability> LearnedAbilities
    {
        get
        {
            return Abilities.Where(x => x.LevelLearned <= Level);
        }
    }
}
