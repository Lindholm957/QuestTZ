using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Data;
using DefaultNamespace;
using UnityEngine;

public class Journal : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;
    [SerializeField] private HeroesSelector _heroesSelector;
    [SerializeField] private QuestsUiManager _uiManager;
    [SerializeField] private List<QuestWrapper> _startQuests = new List<QuestWrapper>();

    private List<QuestWrapper> _completedQuests;
    
    private Dictionary<int, QuestWrapper> _questWrappersDict;

    private void Awake()
    {
        _completedQuests = new List<QuestWrapper>();
        
        _questWrappersDict = new Dictionary<int, QuestWrapper>();
        for(int i = 0; i < _levelData.QuestWrapperList.Count; i++)
        {
            var qw = _levelData.QuestWrapperList;
            _questWrappersDict.Add(qw[i].Id, _levelData.QuestWrapperList[i]);
        }
        
        for(int i = 0; i < _startQuests.Count; i++)
        {
            _uiManager.InitButton(_startQuests[i].Id, _startQuests[i].MapPosition);
        }
    }

    private void OnEnable()
    {
        _uiManager.QuestSelected.AddListener(OnQuestSelected);
        _uiManager.QuestCompleted.AddListener(OnQuestCompleted);
    }

    private void OnQuestSelected(int id)
    {
        _uiManager.CreateQuestPreviewWindow(_questWrappersDict[id]);
    }
    
    private void OnQuestCompleted(int id, bool isAlternative)
    {
        OpenNewQuests(id, isAlternative);
        
        var completedQD = isAlternative ? _questWrappersDict[id].AlternativeQuest :
            _questWrappersDict[id].FirstQuest;
        
        UnlockHeroReward(completedQD);
        
        _heroesSelector.GiveRewardToHero(completedQD.HeroRewardValue,
            completedQD.AdditionalRewardCharacters, completedQD.AdditionalRewardValue);
    }

    private void OpenNewQuests(int id, bool isAlternative)
    {
        List<QuestWrapper> nextEnableQuests = new List<QuestWrapper>();
        List<QuestWrapper> nextAvailableQuests = new List<QuestWrapper>();
        _completedQuests.Add(_questWrappersDict[id]);

        nextEnableQuests = isAlternative ? _questWrappersDict[id]?.NextEnableAltQuests : _questWrappersDict[id]?.NextEnableQuests;
        foreach (var qw in nextEnableQuests)
        {
            nextAvailableQuests.Add(qw);
        }
        
        foreach (var qw in nextEnableQuests)
        {
            foreach (var completedQuest in _completedQuests)
            {
                if (completedQuest == qw)
                {
                    nextAvailableQuests.Remove(qw);
                }
            }
        }
        foreach (var qw in nextAvailableQuests)
        {
            _uiManager.InitButton(qw.Id, qw.MapPosition);
        }
    }

    private void UnlockHeroReward(QuestData completedQD)
    {
        foreach (var unlockHeroType in completedQD.UnlockHero)
        {
            _heroesSelector.CreateNewHero(unlockHeroType);
        }
    }

    private void OnDisable()
    {
        _uiManager.QuestSelected.RemoveListener(OnQuestSelected);
        _uiManager.QuestCompleted.RemoveListener(OnQuestCompleted);
    }
}
