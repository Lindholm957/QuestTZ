using System.Collections.Generic;
using Data;
using DefaultNamespace;
using UI;
using UnityEngine;
using UnityEngine.Events;

public class QuestsUiManager : MonoBehaviour
{
    [HideInInspector] [SerializeField] private UnityEvent<int> _questSelected = new UnityEvent<int>();
    [SerializeField] private Transform _mapRoot;
    [SerializeField] private GameObject _questButtonPrefab;
    [SerializeField] private Transform _questParent;
    [SerializeField] private GameObject _questPreviewPrefab;
    [SerializeField] private GameObject _doubleQuestPreviewPrefab;

    private List<QuestButton> _questButtons = new List<QuestButton>();
    private QuestWrapper _curOpenedQuest;

    public UnityEvent<int> QuestSelected => _questSelected;
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
            var window = Instantiate(_doubleQuestPreviewPrefab, _questParent);
        }
        else
        {
            var window = Instantiate(_questPreviewPrefab, _questParent);
            window.GetComponent<QuestPreviewUI>().Init(_curOpenedQuest.Id, _curOpenedQuest.FirstQuest);
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
