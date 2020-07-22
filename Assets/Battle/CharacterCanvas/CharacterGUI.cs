using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGUI : MonoBehaviour
{

    Character character;

#pragma warning disable IDE0044 // Add readonly modifier
    [SerializeField]
    private Sprite[] ApBaseSprites;
    [SerializeField]
    private Sprite[] ApFillSprites;
#pragma warning restore IDE0044 // Add readonly modifier

    #region Accessors
    GameObject HPBar
    {
        //this object has 3 children: HPDamaged, HPDamaging, and HPCurrent
        get
        {
            return transform.Find("HPBar").gameObject;
        }
    }

    internal void SetCharacter(Character character)
    {
        this.character = character;

        HPText.text = character.HP_Max.ToString();
        HPBarCurrent.fillAmount = HPBarDamaging.fillAmount = character.HP_Current / character.HP_Max;
        transform.Find("Burst").Find("Portrait").GetComponent<Image>().sprite = character.characterSprite;
        transform.Find("NameText").GetComponent<TextMeshProUGUI>().text = character.CharacterName;
    }

    private Image _hpBarCurrent;
    Image HPBarCurrent
    {
        get
        {
            if (_hpBarCurrent == null)
            {
                if (HPBar == null)
                    return null;
                _hpBarCurrent = HPBar.transform.Find("HPCurrent").gameObject.GetComponent<Image>();
            }
            return _hpBarCurrent;
        }
    }

    private Image _hPBarDamaging;
    Image HPBarDamaging
    {
        get
        {
            if (_hPBarDamaging == null)
            {
                if (HPBar == null)
                    return null;
                _hPBarDamaging = HPBar.transform.Find("HPDamaging").gameObject.GetComponent<Image>();
            }
            return _hPBarDamaging;
        }
    }

    private Image _hPBarDamaged;
    Image HPBarDamaged
    {
        get
        {
            if (_hPBarDamaged == null)
            {
                if (HPBar == null)
                    return null;
                _hPBarDamaged = HPBar.transform.Find("HPDamaged").gameObject.GetComponent<Image>();
            }
            return _hPBarDamaged;
        }
    }

    private Image _aPBase;
    Image APBase
    {
        get
        {
            if (_aPBase == null)
                _aPBase = transform.Find("APBase").GetComponent<Image>();

            return _aPBase;
        }
    }

    private Image _aPFill;
    Image APFill
    {
        get
        {
            if (_aPFill == null)
            {
                if (APBase == null)
                    return null;
                _aPFill = APBase.transform.Find("APFill").GetComponent<Image>();
            }
            return _aPFill;
        }
    }

    private TextMeshProUGUI _hPText;
    TextMeshProUGUI HPText
    {
        get
        {
            if (_hPText = null)
                _hPText = transform.Find("HPText").gameObject.GetComponent<TextMeshProUGUI>();
            return _hPText;
        }
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        UpdateAP();
        ScaleHPTo1();
        SetHPBars();
    }

    private void Start()
    {
        //BattleManager.instance.battleSelectionObservers += Dim;

        //HPText.text = character.HP_Max.ToString();
        //HPBarCurrent.fillAmount = HPBarDamaging.fillAmount = character.HP_Current / character.HP_Max;
        //transform.Find("Burst").Find("Portrait").GetComponent<Image>().sprite = SpriteManager.Instance.CharacterPortraitSprites.characterPortraits[character.PortraitId];
        //transform.Find("NameText").GetComponent<TextMeshProUGUI>().text = character.Name;
    }

    public void Dim(Character c)
    {
        if (c == null || c == character)
            GUIUtility.DimGUI(transform, 1f);
        else
            GUIUtility.DimGUI(transform);
    }

    void UpdateAP()
    {
        if (character == null)
            return;

        int intAP = MathUtility.Truncate(character.APCore.AP_Current).Clamp(0, 10);
        APBase.sprite = ApBaseSprites[intAP];
        APFill.sprite = ApFillSprites[intAP];

        if (intAP > 0)
        {
            APFill.fillAmount = character.APCore.AP_Current % intAP;
        }
        else
        {
            APFill.fillAmount = character.APCore.AP_Current;
        }

        if (character.APCore.AP_Current == 10f)
        {
            APFill.fillAmount = 1;
        }
    }

    void ScaleHPTo1()
    {
        if (HPBar == null || character == null)
            return;

        if (HPBarCurrent.rectTransform.localScale.y <= 1)
        {
            HPBarCurrent.transform.localScale = new Vector3(HPBarCurrent.transform.localScale.x, 1);
        }
        else
        {
            var scale = HPBarCurrent.rectTransform.localScale;
            scale = new Vector3(scale.x, scale.y - (Time.deltaTime * 0.75f));
            if (scale.y < 1)
                scale.y = 1;
            HPBarCurrent.rectTransform.localScale = scale;
        }


        if (HPBarDamaging.rectTransform.localScale.y <= 1)
        {
            HPBarDamaging.transform.localScale = new Vector3(HPBarDamaging.transform.localScale.x, 1);
        }
        else
        {
            var scale = HPBarDamaging.rectTransform.localScale;
            scale = new Vector3(scale.x, scale.y - (Time.deltaTime * 0.75f));
            if (scale.y < 1)
                scale.y = 1;
            HPBarDamaging.rectTransform.localScale = scale;
        }


        if (HPBarDamaged.rectTransform.localScale.y <= 1)
        {
            HPBarDamaged.transform.localScale = new Vector3(HPBarDamaged.transform.localScale.x, 1);
        }
        else
        {
            var scale = HPBarDamaged.rectTransform.localScale;
            scale = new Vector3(scale.x, scale.y - (Time.deltaTime * 0.75f));
            if (scale.y < 1)
                scale.y = 1;
            HPBarDamaged.rectTransform.localScale = scale;
        }
    }

    void SetHPBars()
    {
        if (character == null)
            return;

        float fillAmount = (float)character.HP_Current / (float)character.HP_Max;
        //current
        if (HPBarCurrent.fillAmount != fillAmount)
        { StartScalingHP(); }
        HPBarCurrent.fillAmount = fillAmount;
        //damaging
        if (HPBarDamaging == null || character == null)
            return;
        if (HPBarDamaging.fillAmount <= fillAmount)
        {
            HPBarDamaging.fillAmount = fillAmount;
        }
        else
        {
            HPBarDamaging.fillAmount -= Time.deltaTime * 0.1f;
        }
        if (HPText.text != character.HP_Current.ToString())
            StartScalingHP();
        HPText.text = character.HP_Current.ToString();
        return;

    }

    void StartScalingHP()
    {
        var scale = new Vector3(1, 1.4f);
        HPBarCurrent.rectTransform.localScale = scale;
        HPBarDamaged.rectTransform.localScale = scale;
        HPBarDamaging.rectTransform.localScale = scale;
    }
}
