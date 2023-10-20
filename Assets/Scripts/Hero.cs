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
    private int _exp;
    private CharactersTypes.HeroType _type;

    public CharactersTypes.HeroType Type => _type;

    public void Init(ToggleGroup group, CharactersTypes.HeroType type)
    {
        _toggle = GetComponent<Toggle>();
        _toggle.group = group;
        _type = type;
    }

    public void OnToggleClicked(bool isClicked)
    {
        _toggle.isOn = !_toggle.isOn;
    }
}
