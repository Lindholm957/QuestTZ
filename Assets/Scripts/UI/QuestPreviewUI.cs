using Data;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class QuestPreviewUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _preText;
        [SerializeField] private Button _startButton;

        private int _id;

        public void Init(int id, QuestData questData)
        {
            _id = id;
            _title.text = questData.name;
            _image.sprite = questData.MissionImage;
            _preText.text = questData.Text;
        }
    }
}