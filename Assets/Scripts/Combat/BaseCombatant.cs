using UnityEngine;
using UnityEngine.UI;

namespace Combat
{
    public abstract class BaseCombatant : MonoBehaviour
    {
        public bool IsDead { get; private set; }
        public int CurHealth { get; private set; }

        [SerializeField]
        private int _maxHealth;

        [SerializeField]
        private Slider _healthBarUI;

        [SerializeField]
        private float _destroyDelayOnDeath = 2f;

        private void Awake()
        {
            CurHealth = _maxHealth;
            _healthBarUI.maxValue = CurHealth;
        }

        public void TakeDamage(int damageTake)
        {
            CurHealth -= damageTake;

            _healthBarUI.value = CurHealth;

            if (CurHealth <= 0)
            {
                Died();
            }
        }

        private void Died()
        {
            IsDead = true;
            Destroy(gameObject, _destroyDelayOnDeath);
        }
    }
}