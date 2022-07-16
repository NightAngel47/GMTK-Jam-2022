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
        private List<EnemyBehaviour> enemies = new List<EnemyBehaviour>();
        
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
            yield return new WaitUntil(() => enemies.All(enemy => enemy.IsDoneMoving()));
            // add more things to wait for before ending turn
                
            EndTurn();
        }

        private void TakeEnemyTurns()
        {
            Vector3 playerPosition = PlayerController.Instance.transform.position;
            foreach (EnemyBehaviour enemy in enemies.OrderBy(e => Vector2.Distance(e.transform.position, playerPosition)))
            {
                enemy.DoAction();
            }
        }

        private void SpawmEnemies()
        {
            enemies.Add(EnemySpawner.Instance.SpawnEnemy(Combat.EnemyTypes.Normal));
        }
    }
}