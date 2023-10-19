using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HeroesSelector : MonoBehaviour
{
    [SerializeField] private Transform _root;
    [SerializeField] private GameObject _heroPrefab;
    [SerializeField] private ToggleGroup _toggleGroup;

    private List<Hero> _heroesList = new List<Hero>();

    public Hero CurHero => _toggleGroup.GetFirstActiveToggle().GetComponent<Hero>();
    public bool IsHeroSelected => CurHero != null;

    private void Awake()
    {
        var hero = Instantiate(_heroPrefab, _root).GetComponent<Hero>();
        hero.Init(_toggleGroup);
        _heroesList.Add(hero);
    }
}
