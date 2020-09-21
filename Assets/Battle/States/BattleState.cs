using UnityEngine;

[CreateAssetMenu(fileName = "BattleState", menuName = "ScriptableObjects/BattleState", order = 1)]
public class BattleState : ScriptableObject
{
    public string stateName;
    public string InputMapName;
    public BattleState nextState;
    public BattleState previousState;
}
