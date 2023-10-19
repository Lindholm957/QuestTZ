using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "QuestData", menuName = "Quest Data")]
    public class QuestData : ScriptableObject
    {
        [SerializeField] private float _number;
        [SerializeField] private string _name;
        [SerializeField] private Sprite _missionImage;
        [TextArea(4,10)][SerializeField] private string _preText;
        [TextArea(6,10)][SerializeField] private string _text;
        [SerializeField] private List<CharactersTypes.Type> _allyType = new List<CharactersTypes.Type>();
        [SerializeField] private List<CharactersTypes.Type> _enemyType = new List<CharactersTypes.Type>();
        [CanBeNull][SerializeField] private List<CharactersTypes.Type> _unlockHero = new List<CharactersTypes.Type>();
        [SerializeField] private double _heroRewardValue;
        [CanBeNull][SerializeField] private List<CharactersTypes.Type> _additionalRewardCharacters= new List<CharactersTypes.Type>();
        [CanBeNull][SerializeField] private double _additionalRewardValue;
        
        public float Number => _number;
        public string Name => _name;
        public Sprite MissionImage => _missionImage;
        public string PreText => _preText;
        public string Text => _text;
        public List<CharactersTypes.Type> AllyType => _allyType;
        public List<CharactersTypes.Type> EnemyType => _enemyType;
        public List<CharactersTypes.Type> UnlockHero => _unlockHero;
        public double HeroRewardValue => _heroRewardValue;
        public List<CharactersTypes.Type> AdditionalRewardCharacters => _additionalRewardCharacters;
        public double AdditionalRewardValue => _additionalRewardValue;
    }
}