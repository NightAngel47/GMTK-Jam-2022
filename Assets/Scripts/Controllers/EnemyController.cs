using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Movement;

namespace Controllers
{
    public class EnemyController : BaseController
    {
        public static EnemyController Instance { get; private set; }
        [SerializeField]
        private List<EnemyBehaviour> _enemies = new List<EnemyBehaviour>();
        
        private void Awake()
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else
            { 
                Instance = this; 
            }
        }

        public override void StartTurn()
        {
            base.StartTurn();

            TakeEnemyTurns();

            SpawmEnemies();

            StartCoroutine(WaitForEndOfTurn());
        }
        
        protected override IEnumerator WaitForEndOfTurn()
        {
            yield return new WaitUntil(() => _enemies.All(enemy => enemy.IsDoneMoving()));
            // add more things to wait for before ending turn

            List<EnemyBehaviour> enemiesDying = _enemies.Where(enemyBehaviour => enemyBehaviour.IsDying()).ToList();
            foreach (var enemyBehaviour in enemiesDying.Where(enemyBehaviour => _enemies.Any(enemy => enemyBehaviour == enemy)))
            {
                _enemies.Remove(enemyBehaviour);
            }
            yield return new WaitUntil(() => enemiesDying.All(enemy => !enemy.IsDying()));
                
            EndTurn();
        }

        private void TakeEnemyTurns()
        {
            Vector3 playerPosition = PlayerController.Instance.transform.position;
            foreach (EnemyBehaviour enemy in _enemies.OrderBy(e => Vector2.Distance(e.transform.position, playerPosition)))
            {
                enemy.DoAction();
            }
        }

        private void SpawmEnemies()
        {
            _enemies.Add(EnemySpawner.Instance.SpawnEnemy(Combat.EnemyTypes.Normal));
        }
    }
}