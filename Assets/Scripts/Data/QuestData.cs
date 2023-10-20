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
        [SerializeField] private List<CharactersTypes.Fraction> _allyType = new List<CharactersTypes.Fraction>();
        [SerializeField] private List<CharactersTypes.Fraction> _enemyType = new List<CharactersTypes.Fraction>();
        [CanBeNull][SerializeField] private List<CharactersTypes.HeroType> _unlockHero = new List<CharactersTypes.HeroType>();
        [SerializeField] private double _heroRewardValue;
        [CanBeNull][SerializeField] private List<CharactersTypes.HeroType> _additionalRewardCharacters= new List<CharactersTypes.HeroType>();
        [CanBeNull][SerializeField] private double _additionalRewardValue;
        
        public float Number => _number;
        public string Name => _name;
        public Sprite MissionImage => _missionImage;
        public string PreText => _preText;
        public string Text => _text;
        public List<CharactersTypes.Fraction> AllyType => _allyType;
        public List<CharactersTypes.Fraction> EnemyType => _enemyType;
        public List<CharactersTypes.HeroType> UnlockHero => _unlockHero;
        public double HeroRewardValue => _heroRewardValue;
        public List<CharactersTypes.HeroType> AdditionalRewardCharacters => _additionalRewardCharacters;
        public double AdditionalRewardValue => _additionalRewardValue;
    }
}