using UnityEngine;

namespace SERESESTUDIO.UI
{
    public class ButtonTextColor : MonoBehaviour
    {
        public Color NormalColor => _NormalColor;
        public Color selectedColor => _selectedColor;
        public Color textNormalColor => _textNormalColor;
        public Color textSelectedColor => _textSelectedColor;
        public Sprite normalSprite => _normalSprite;
        public Sprite selectedSprite => _selectedSprite;
        
        [SerializeField]
        private Color _NormalColor;
        [SerializeField]
        private Color _selectedColor;
        [SerializeField]
        private Color _textNormalColor;
        [SerializeField]
        private Color _textSelectedColor;
        [SerializeField]
        private Sprite _normalSprite;
        [SerializeField]
        private Sprite _selectedSprite;

        public void SetSelected(bool isSelected)
        {
            GetComponent<UnityEngine.UI.Image>().color = isSelected ? _selectedColor : _NormalColor;
            GetComponent<UnityEngine.UI.Image>().sprite = isSelected ? _selectedSprite : _normalSprite;
            var textComponent = GetComponentInChildren<TMPro.TMP_Text>();
            if (textComponent != null)
            {
                textComponent.color = isSelected ? _textSelectedColor : _textNormalColor;
            }
        }
    }
}