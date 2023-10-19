using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class QuestButton : MonoBehaviour
    {
        [HideInInspector] [SerializeField] private UnityEvent<int> _buttonClicked = new UnityEvent<int>();

        public UnityEvent<int> ButtonClicked => _buttonClicked;
        private int _id;
        public void Init(int id)
        {
            _id = id;
        }

        public void OnClick()
        {
            _buttonClicked.Invoke(_id);
        }
    }
}