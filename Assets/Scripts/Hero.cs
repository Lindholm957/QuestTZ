using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameField;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _expField;
    
    private Toggle _toggle;
    private double _exp;
    private CharactersTypes.HeroType _type;

    public CharactersTypes.HeroType Type => _type;

    public void Init(ToggleGroup group, CharactersTypes.HeroType type)
    {
        _toggle = GetComponent<Toggle>();
        _toggle.group = group;
        _type = type;
        _expField.text = _exp.ToString();
        _nameField.text = CharactersTypes.GetHeroName(_type);
    }

    public void ChangeExp(double value)
    {
        _exp += value;
        _expField.text = _exp.ToString();
    }
}
