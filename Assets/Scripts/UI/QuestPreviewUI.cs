using Data;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class QuestPreviewUI : MonoBehaviour
    {
        [HideInInspector] [SerializeField] private UnityEvent<int, bool> _questStarted = new UnityEvent<int, bool>();
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _preText;

        private int _id;
        private bool _isAlternative;
        public UnityEvent<int, bool> QuestStarted => _questStarted;

        public void Init(int id, QuestData questData, bool isAlternative)
        {
            _id = id;
            _title.text = questData.Name;
            _image.sprite = questData.MissionImage;
            _preText.text = questData.Text;
            _isAlternative = isAlternative;
        }

        public void OnClick()
        {
            _questStarted.Invoke(_id, _isAlternative);
        }
    }
}