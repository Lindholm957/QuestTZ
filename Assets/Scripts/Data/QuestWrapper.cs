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
        [SerializeField] private QuestData _firstQuest;
        [CanBeNull][SerializeField]private QuestData _alternativeQuest;
    }
}