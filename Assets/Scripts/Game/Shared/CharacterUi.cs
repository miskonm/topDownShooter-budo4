using TDS.Game.Objects;
using TDS.Game.UI;
using UnityEngine;

namespace TDS.Game
{
    public class CharacterUi : MonoBehaviour
    {
        [SerializeField] private HpBar _hpBar;

        private IHealth _health;

        private void Awake()
        {
            Construct(GetComponentInChildren<IHealth>());
        }

        private void OnDestroy()
        {
            if (_health != null)
            {
                _health.OnChanged -= HpChanged;
            }
        }

        public void Construct(IHealth health)
        {
            _health = health;

            if (_health != null)
            {
                _health.OnChanged += HpChanged;
                HpChanged(_health.CurrentHp);
            }
        }

        private void HpChanged(int currentHp)
        {
            float fillAmount = currentHp / (float)_health.MaxHp;
            _hpBar.SetFill01(fillAmount);
        }
    }
}