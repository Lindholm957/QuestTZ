using Unity.VisualScripting;
using UnityEngine;

namespace UI
{
    public class DoubleQuestPreviewUI : MonoBehaviour
    {
        [SerializeField] private QuestPreviewUI _firstQuest;
        [SerializeField] private QuestPreviewUI _alternativeQuest;

        public QuestPreviewUI FirstQuest => _firstQuest;
        public QuestPreviewUI AlternativeQuest => _alternativeQuest;
    }
}