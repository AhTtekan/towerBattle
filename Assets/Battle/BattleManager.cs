using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public IEnumerable<Unit> Enemies { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Enemies = new List<Unit>()
        {
            new Unit
            {
                CharacterName = "Slime",
                targetType = TargetTypes.Enemy
            },
            new Unit
            {
                CharacterName = "Chicken",
                targetType = TargetTypes.Enemy
            }
        };
    }
}
