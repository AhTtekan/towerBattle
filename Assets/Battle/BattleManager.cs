using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public BattleQueueGUI battleQueueGUI;

    public Transform CharacterGUIPrefab;

    public Encounter Encounter;

    public Sprite[] ApBaseSprites;
    public Sprite[] ApFillSprites;

    //public IEnumerable<Unit> Enemies { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        BuildCharacterGUIs();
        InitializeQueueGUI();
    }

    private void InitializeQueueGUI()
    {
        battleQueueGUI.Initialize(10);
    }

    private void BuildCharacterGUIs()
    {
        var characters = GameObject.FindObjectOfType<CharacterManager>().Characters;
        var guis = GameObject.FindObjectsOfType<CharacterGUI>();

        for (int i = 0; i < guis.Length; i++)
        {
            if (i >= characters.Length)
            {
                guis[i].gameObject.SetActive(false);

                continue;
            }

            guis[i].SetCharacter(characters[i]);
        }
    }
}
