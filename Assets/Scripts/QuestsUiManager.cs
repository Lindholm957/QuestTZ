using System.Collections.Generic;
using Data;
using DefaultNamespace;
using UI;
using UnityEngine;

public class QuestsUiManager : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;
    [SerializeField] private Transform _mapRoot;
    [SerializeField] private List<QuestWrapper> _startQuests = new List<QuestWrapper>();
    [SerializeField] private GameObject _questButtonPrefab;

    private Dictionary<int, QuestWrapper> _questWrappersDict;
    private List<QuestButton> _questButtons;
    private QuestWrapper _curQuestWrapper;
    private void Awake()
    {
        _questWrappersDict = new Dictionary<int, QuestWrapper>();
        for(int i = 0; i < _levelData.QuestWrapperList.Count; i++)
        {
            _questWrappersDict.Add(i, _levelData.QuestWrapperList[i]);
        }
        
        _questButtons = new List<QuestButton>();
        for(int i = 0; i < _startQuests.Count; i++)
        {
            var button = Instantiate(_questButtonPrefab, _mapRoot);
            button.GetComponent<Transform>().localPosition = _startQuests[i].MapPosition;
            var questButton = button.GetComponent<QuestButton>();
            questButton.Init(_startQuests[i].Id);
            _questButtons.Add(questButton);
        }
    }

    private void OnEnable()
    {
        foreach (var btn in _questButtons)
        {
            btn.ButtonClicked.AddListener(OnQuestBtnClicked);
        }
    }

    private void OnQuestBtnClicked(int id)
    {
        Debug.Log("TEST");
        _curQuestWrapper = _questWrappersDict[id];
    }
    
    private void OnDestroy()
    {
        foreach (var btn in _questButtons)
        {
            btn.ButtonClicked.RemoveListener(OnQuestBtnClicked);
        }
    }
}
