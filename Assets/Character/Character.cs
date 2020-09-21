using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Character : Unit
{
    public int Level;

    public Sprite characterSprite;

    public Ability[] Abilities;

    public IEnumerable<Ability> LearnedAbilities
    {
        get
        {
            return Abilities.Where(x => x.LevelLearned <= Level);
        }
    }
}