using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Ability", order = 2)]
public class Ability : ScriptableObject, IQueueable
{
    public int levelLearned;
    public virtual int LevelLearned
    {
        get
        {
            return levelLearned;
        }
        set
        {
            levelLearned = value;
        }
    }

    public string name;
    public virtual string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public int apCost;
    public virtual int APCost { get { return apCost; } }

    public TargetTypes targetType;
    public virtual TargetTypes TargetType
    {
        get
        {
            return targetType;
        }
        set
        {
            targetType = value;
        }
    }
}