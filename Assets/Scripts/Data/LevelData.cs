using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Level Data")]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private List<QuestWrapper> _questWrappersList = new List<QuestWrapper>();

        public List<QuestWrapper> QuestWrapperList => _questWrappersList;
    }
}