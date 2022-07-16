using UnityEngine;

namespace Combat
{
    public abstract class BaseCombatant : MonoBehaviour
    {
        public bool IsDead { get; private set; }
        public int CurHealth { get; private set; }

        public int MaxHealth
        {
            get => _maxHealth;
            private set => _maxHealth = value;
        }

        [SerializeField]
        private int _maxHealth;

        public void TakeDamage(int damageTake)
        {
            CurHealth -= damageTake;

            if (CurHealth <= 0)
            {
                Died();
            }
        }

        private void Died()
        {
            IsDead = true;
            Destroy(gameObject, 2f);
        }
    }
}