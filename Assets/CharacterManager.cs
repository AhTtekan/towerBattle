using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Inventory Inventory { get; set; }

    [SerializeField]
    public PartyMember[] Characters;

    // Start is called before the first frame update
    void Start()
    {
        Inventory = new Inventory();

        DontDestroyOnLoad(this);
    }
}
