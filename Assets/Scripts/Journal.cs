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

    private List<Quest> _activeQuests;
    private List<Quest> _completedQuests;
    private List<Quest> _disabledQuests;
    
    private Dictionary<int, QuestWrapper> _questWrappersDict;

    private void Awake()
    {
        _activeQuests = new List<Quest>();
        _completedQuests = new List<Quest>();
        _disabledQuests = new List<Quest>();
        
        _questWrappersDict = new Dictionary<int, QuestWrapper>();
        for(int i = 0; i < _levelData.QuestWrapperList.Count; i++)
        {
            _questWrappersDict.Add(i, _levelData.QuestWrapperList[i]);
        }
        
        for(int i = 0; i < _startQuests.Count; i++)
        {
            _uiManager.InitButton(_startQuests[i].Id, _startQuests[i].MapPosition);
        }
    }

    private void OnEnable()
    {
        _uiManager.QuestSelected.AddListener(OnQuestSelected);
    }

    private void OnQuestSelected(int id)
    {
        _uiManager.CreateQuestPreviewWindow(_questWrappersDict[id]);
    }
    
    private void OnDisable()
    {
        _uiManager.QuestSelected.RemoveListener(OnQuestSelected);
    }
}
