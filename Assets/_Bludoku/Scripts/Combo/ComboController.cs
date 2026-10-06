using _Bludoku.Scripts.Events;
using UnityEngine;
using EventType = _Bludoku.Scripts.Events.EventType;

namespace _Bludoku.Scripts.Combo
{
    public class ComboController : MonoBehaviour
    {
        [SerializeField] private ComboView comboView;
        
        private void Awake()
        {
            EventsBus.Instance.Subscribe(OnEvent, EventType.MoveFinished);
        }

        private void OnEvent(EventType eventType, object data)
        {
            var isMatch = (bool)(data ?? 0);
            comboView.UpdateCombo(isMatch);
        }
    }
}