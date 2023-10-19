using System.Collections.Generic;
using DefaultNamespace;
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "QuestWrapper", menuName = "Quest Wrapper")]
    public class QuestWrapper : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private QuestData _firstQuest;
        [CanBeNull][SerializeField]private QuestData _alternativeQuest;
        [SerializeField] private Vector2 _mapPosition;
        [CanBeNull][SerializeField]private List<QuestWrapper> _nextEnableQuests = new List<QuestWrapper>();
        [CanBeNull][SerializeField]private List<QuestWrapper> _nextEnableAltQuests = new List<QuestWrapper>();

        public int Id => _id;
        public bool IsDoubleQuest => _firstQuest != null & _alternativeQuest != null;
        public QuestData FirstQuest => _firstQuest;
        public QuestData SecondQuest => _alternativeQuest;
        public Vector2 MapPosition => _mapPosition;
        public List<QuestWrapper> NextEnableQuests => _nextEnableQuests;
        public List<QuestWrapper> NextEnableAltQuests => _nextEnableAltQuests;

    }
}