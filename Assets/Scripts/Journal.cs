using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using DefaultNamespace;
using UnityEngine;

public class Journal : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;
    [SerializeField] private QuestsUiManager _uiManager;
    [SerializeField] private List<QuestWrapper> _startQuests = new List<QuestWrapper>();

    // private List<Quest> _activeQuests;
    // private List<Quest> _completedQuests;
    // private List<Quest> _disabledQuests;
    
    private Dictionary<int, QuestWrapper> _questWrappersDict;

    private void Awake()
    {
        // _activeQuests = new List<Quest>();
        // _completedQuests = new List<Quest>();
        // _disabledQuests = new List<Quest>();
        
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

        // foreach (var kv in _questWrappersDict)
        // {
        //     Debug.Log(kv.Key + " - " + kv.Value.FirstQuest.Name);
        // }
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
        List<QuestWrapper> newQuests = new List<QuestWrapper>();
        newQuests = isAlternative ? _questWrappersDict[id]?.NextEnableAltQuests : _questWrappersDict[id]?.NextEnableQuests;
        foreach (var qw in newQuests)
        {
            _uiManager.InitButton(qw.Id, qw.MapPosition);
        }
    }
    
    private void OnDisable()
    {
        _uiManager.QuestSelected.RemoveListener(OnQuestSelected);
        _uiManager.QuestCompleted.RemoveListener(OnQuestCompleted);
    }
}
