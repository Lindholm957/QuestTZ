using Data;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class QuestUI : MonoBehaviour
    {        
        [HideInInspector] [SerializeField] private UnityEvent<int, bool> _questCompleted = new UnityEvent<int, bool>();
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Image _image;

        [SerializeField] private TMP_Text _allyName;
        [SerializeField] private TMP_Text _questText;
        [SerializeField] private TMP_Text _enemyName;
        
        private int _id;
        private bool _isAlternative;
        public UnityEvent<int, bool> QuestCompleted => _questCompleted;

        public void Init(int id, QuestData questData, bool isAlternative)
        {
            _id = id;
            _isAlternative = isAlternative;
            _title.text = questData.Name;
            _image.sprite = questData.MissionImage;
            _allyName.text += CharactersTypes.GetFractionNames(questData.AllyType);
            _questText.text = questData.Text;
            _enemyName.text += CharactersTypes.GetFractionNames(questData.EnemyType);
        }

        public void FinishQuest()
        {
            _questCompleted.Invoke(_id, _isAlternative);
        }
        
        
        // public enum Type
        // {
        //     Single,
        //     Double
        // }
        //
        // public enum State
        // {
        //     Active,
        //     Disabled,
        //     TemporarilyDisabled,
        //     Completed
        // }
        //
        // private Type _type;
        // private State _state;
        // private string _name;
        // private string _preText;
        // private string _text;

    }
}