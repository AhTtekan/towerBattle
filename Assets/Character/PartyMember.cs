using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Character", order = 1)]
public class PartyMember : Character
{
    public override TargetTypes targetType => TargetTypes.Ally;
}
