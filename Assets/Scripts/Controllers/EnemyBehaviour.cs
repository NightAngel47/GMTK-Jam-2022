using System.Collections.Generic;
using CharacterActions;
using Combat;
using Movement;
using UnityEngine;

namespace Controllers
{
    public class EnemyBehaviour : MonoBehaviour
    {
        private EnemyMovement _enemyMovement;
        private EnemyCombatant _enemyCombatant;

        [SerializeField]
        private List<EnemyAction> _enemyActions;

        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
            _enemyCombatant = GetComponent<EnemyCombatant>();
        }

        public void DoAction()
        {
            Vector2 dir = PlayerController.Instance.transform.position - transform.position;
                
            if (dir.magnitude <= 1)
            {
                // Attack
            }
            else
            {
                _enemyActions[0].ExecuteAction(dir, _enemyMovement);
            }
        }

        public bool IsDoneMoving()
        {
            return _enemyMovement.DoneMoving;
        }
    }
}