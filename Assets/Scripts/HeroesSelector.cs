using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HeroesSelector : MonoBehaviour
{
    [SerializeField] private Transform _root;
    [SerializeField] private CharactersTypes.HeroType _defaultHeroType;
    [SerializeField] private GameObject _heroPrefab;
    [SerializeField] private ToggleGroup _toggleGroup;

    private List<Hero> _heroesList = new List<Hero>();

    public Hero CurHero => _toggleGroup.GetFirstActiveToggle().GetComponent<Hero>();
    public bool IsHeroSelected => CurHero != null;

    private void Awake()
    {
        CreateNewHero(_defaultHeroType);
    }

    public void CreateNewHero(CharactersTypes.HeroType type)
    {
        var hero = Instantiate(_heroPrefab, _root).GetComponent<Hero>();
        hero.Init(_toggleGroup, type);
        _heroesList.Add(hero);
    }
}
