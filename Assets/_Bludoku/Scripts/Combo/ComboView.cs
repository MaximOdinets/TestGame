using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Bludoku.Scripts.Combo
{
    public class ComboView : MonoBehaviour
    {
        [SerializeField] private TMP_Text comboText;

        
        private const float UpdateDuration = 0.2f;
        private const float StartDuration = 0.2f;
        private const float FinishDuration = 0.2f;
        
        private bool _comboEnabled;
        private int _comboCounter = 0;

        public void UpdateCombo(bool comboEnabled)
        {
            if (_comboEnabled && comboEnabled)
            {
                ++_comboCounter;
                if (_comboCounter == 1)
                    StartAnimation();
                else
                    UpdateAnimation();
            }

            if (_comboEnabled && !comboEnabled)
            {
                _comboCounter = 0;
                FinishAnimation();
            }

            _comboEnabled = comboEnabled;
        }

        private void StartAnimation()
        {
            comboText.CrossFadeAlpha(1, StartDuration, true);
            comboText.text = _comboCounter.ToString();
            InstantiateComboText();
        }
        
        private void FinishAnimation()
        {
            comboText.text = _comboCounter.ToString();
            comboText.CrossFadeAlpha(0, FinishDuration, true);
        }

        private void UpdateAnimation()
        {
            comboText.text = _comboCounter.ToString();
            comboText.transform.DOPunchScale(Vector3.one * 0.5f, UpdateDuration, 1, 0.5f);
            InstantiateComboText();
        }

        private void InstantiateComboText()
        {
            var resource = Resources.Load("Combo");
            var instance = Instantiate(resource);
        }
    }
}