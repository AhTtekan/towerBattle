using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Encounter", order = 3)]
public class Encounter : ScriptableObject
{
    public Unit[] Enemies;

    //Loot

    public int Experience;
}
