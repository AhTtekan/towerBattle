using UnityEngine;
using UnityEngine.UIElements;

public class Item : ScriptableObject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}