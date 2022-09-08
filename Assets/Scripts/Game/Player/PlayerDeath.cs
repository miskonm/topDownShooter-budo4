using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private PlayerHp _playerHp;
        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerAttack _playerAttack;

        public bool IsDead { get; private set; }

        private void Start()
        {
            _playerHp.OnChanged += OnHpChanged;
        }

        private void OnHpChanged(int hp)
        {
            if (IsDead || hp > 0)
                return;

            IsDead = true;
            _playerAnimation.PlayDeath();
            _playerMovement.enabled = false;
            _playerAttack.enabled = false;
        }
    }
}