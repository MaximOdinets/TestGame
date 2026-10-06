using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Bludoku.Scripts.Combo
{
    public class ComboTextView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private const float introDuration = 0.5f;
        private const float outroDuration = 0.5f;
        
        private void Awake()
        {
            StartCoroutine(Animation());
        }

        private IEnumerator Animation()
        {
            _text.transform.localScale = Vector3.zero;
            
            yield return new WaitForSeconds(0.2f);

            yield return _text.transform.DOScale(Vector3.one, introDuration).SetEase(Ease.OutBounce).WaitForCompletion();

            _text.CrossFadeAlpha(0, outroDuration, true);
            _text.transform.DOScale(Vector3.one * 1.5f, outroDuration).SetEase(Ease.Linear);

            yield return new WaitForSeconds(outroDuration);
            
            Destroy(gameObject);
        }
    }
}