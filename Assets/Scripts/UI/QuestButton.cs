using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class QuestButton : MonoBehaviour
    {
        [HideInInspector] [SerializeField] private UnityEvent<int> _buttonClicked = new UnityEvent<int>();
        
        private int _id;
        private Button _button;
       
        public UnityEvent<int> ButtonClicked => _buttonClicked;
        public int Id => _id;

        public void Init(int id)
        {
            _id = id;
            _button = GetComponent<Button>();
        }

        public void OnClick()
        {
            _buttonClicked.Invoke(_id);
        }

        public void DisableButton()
        {
            _button.interactable = false;
        }
    }
}