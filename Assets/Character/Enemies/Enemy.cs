using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemy", order = 4)]
public class Enemy : Character
{
    public override TargetTypes targetType { get => TargetTypes.Enemy; }
}
