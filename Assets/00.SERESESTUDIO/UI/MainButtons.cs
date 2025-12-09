using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SERESESTUDIO.UI
{   
    public class MainButtons : MonoBehaviour
    {
        public Color NormalColor => _NormalColor;
        public Color selectedColor => _selectedColor;
        public Button[] buttons => _buttons;
        [SerializeField]
        private int _index;

        [SerializeField]
        private Color _NormalColor;
        [SerializeField]
        private Color _selectedColor;
        [SerializeField]
        private Button[] _buttons;
        private void Start()
        {
            SetIndex(_index);
        }
        public void SetIndex(int index)
        {
            _index = index;
            for(int i = 0; i < _buttons.Length; i++)
            {
                if(i == _index)
                {
                    _buttons[i].GetComponent<Image>().color = _selectedColor;
                    if(_buttons[i].GetComponentInChildren<TMP_Text>()) 
                    {
                        _buttons[i].GetComponentInChildren<TMP_Text>().color = _selectedColor;
                    }
                }
                else
                {
                    _buttons[i].GetComponent<Image>().color = _NormalColor;
                    if(_buttons[i].GetComponentInChildren<TMP_Text>()) 
                    {
                        _buttons[i].GetComponentInChildren<TMP_Text>().color = _NormalColor;
                    }
                }
            }
        }
    }
}
