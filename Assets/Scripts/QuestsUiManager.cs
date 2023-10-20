using System.Collections.Generic;
using Data;
using DefaultNamespace;
using UI;
using UnityEngine;
using UnityEngine.Events;

public class QuestsUiManager : MonoBehaviour
{
    [HideInInspector] [SerializeField] private UnityEvent<int> _questSelected = new UnityEvent<int>();
    [HideInInspector] [SerializeField] private UnityEvent<int, bool> _questCompleted = new UnityEvent<int, bool>();
    [SerializeField] private Transform _mapRoot;
    [SerializeField] private GameObject _questButtonPrefab;
    [SerializeField] private Transform _questParent;
    [SerializeField] private GameObject _questPreviewPrefab;
    [SerializeField] private GameObject _doubleQuestPreviewPrefab;
    [SerializeField] private GameObject _questPrefab;

    private List<QuestButton> _questButtons = new List<QuestButton>();
    private QuestWrapper _curOpenedQuest;

    public UnityEvent<int> QuestSelected => _questSelected;
    public UnityEvent<int, bool> QuestCompleted => _questCompleted;
    public void InitButton(int id, Vector2 mapPosition)
    {
        var button = Instantiate(_questButtonPrefab, _mapRoot);
        button.GetComponent<Transform>().localPosition = mapPosition;
        
        var questButton = button.GetComponent<QuestButton>();
        questButton.Init(id);
        
        _questButtons.Add(questButton);
        _questButtons[_questButtons.Count-1].ButtonClicked.AddListener(OnQuestBtnClicked);
    }

    private void OnQuestBtnClicked(int id)
    {
        _questSelected.Invoke(id);
    }

    public void CreateQuestPreviewWindow(QuestWrapper questWrapper) 
    {
        _curOpenedQuest = questWrapper;
        if (_curOpenedQuest.IsDoubleQuest)
        {
            var window = Instantiate(_doubleQuestPreviewPrefab, _questParent).GetComponent<DoubleQuestPreviewUI>();
            window.FirstQuest.Init(questWrapper.Id, _curOpenedQuest.FirstQuest, false);
            window.AlternativeQuest.Init(questWrapper.Id, _curOpenedQuest.AlternativeQuest, true);
            
            window.FirstQuest.QuestStarted.AddListener(OnQuestStarted);
            window.AlternativeQuest.QuestStarted.AddListener(OnQuestStarted);
        }
        else
        {
            var window = Instantiate(_questPreviewPrefab, _questParent).GetComponent<QuestPreviewUI>();
            window.Init(questWrapper.Id, _curOpenedQuest.FirstQuest, false);
            
            window.QuestStarted.AddListener(OnQuestStarted);
        }
    }

    private void OnQuestStarted(int id, bool isAlternative)
    {
        RemoveAllWindows();
        CreateQuestWindow(id, isAlternative);
    }

    private void CreateQuestWindow(int id, bool isAlternative)
    {
        var quest = Instantiate(_questPrefab, _questParent).GetComponent<QuestUI>();
        QuestData questData = isAlternative ? _curOpenedQuest.AlternativeQuest : _curOpenedQuest.FirstQuest;
        quest.Init(id, questData, isAlternative);
        quest.QuestCompleted.AddListener(OnQuestCompleted);
    }

    private void OnQuestCompleted(int id, bool isAlternative)
    {
        RemoveAllWindows();
        _questCompleted.Invoke(id, isAlternative);
    }

    private void RemoveAllWindows()
    {
        foreach (Transform child in _questParent)
        {
            Destroy(child.gameObject);
        }
    }
    
    private void OnDisable()
    {
        foreach (var btn in _questButtons)
        {
            btn.ButtonClicked.RemoveListener(OnQuestBtnClicked);
        }
    }
}
