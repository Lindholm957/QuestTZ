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
    [SerializeField] private CharactersTypes.Type _type;
    [SerializeField] private TMP_Text _nameField;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _expField;
    
    private Toggle _toggle;
    private int _exp;

    public void Init(ToggleGroup group)
    {
        _toggle = GetComponent<Toggle>();
        _toggle.group = group;
    }

    public void OnToggleClicked(bool isClicked)
    {
        _toggle.isOn = !_toggle.isOn;
    }
}
