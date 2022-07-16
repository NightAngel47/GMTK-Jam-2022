using UnityEngine;

namespace Combat
{
    public enum EnemyTypes
    {
        None = -1,
        Normal = 0
    }
    
    class EnemyCombatant : BaseCombatant
    {
        [SerializeField]
        private EnemyTypes _enemyTypes = EnemyTypes.None;

        public EnemyTypes EnemyTypes
        {
            get => _enemyTypes;
            private set => _enemyTypes = value;
        }
    }
}