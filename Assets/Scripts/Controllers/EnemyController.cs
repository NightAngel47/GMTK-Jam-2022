using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

        public override IEnumerator StartTurn()
        {
            StartCoroutine(base.StartTurn());

            yield return new WaitUntil(() => IsTurn);

            TakeEnemyTurns();
            yield return new WaitUntil(() => _enemies.All(enemy => enemy.IsDoneMoving()));
            // TODO add wait for attacks
            
            // wait for the dead
            yield return new WaitUntil(() => RemoveDeadEnemies().All(enemy => !enemy.IsDying()));
            
            // wait for spawning
            yield return new WaitUntil(SpawnEnemies);
            
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

        private List<EnemyBehaviour> RemoveDeadEnemies()
        {
            List<EnemyBehaviour> enemiesDying = _enemies.Where(enemyBehaviour => enemyBehaviour.IsDying()).ToList();
            foreach (var enemyBehaviour in enemiesDying.Where(enemyBehaviour => _enemies.Any(enemy => enemyBehaviour == enemy)))
            {
                _enemies.Remove(enemyBehaviour);
            }

            return enemiesDying;
        }

        private bool SpawnEnemies()
        {
            _enemies.Add(EnemySpawner.Instance.SpawnEnemy(Combat.EnemyTypes.Normal));

            return true;
        }
    }
}