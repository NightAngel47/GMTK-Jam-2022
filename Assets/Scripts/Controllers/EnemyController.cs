using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Movement;

namespace Controllers
{
    public class EnemyController : BaseController
    {
        public static EnemyController Instance { get; private set; }
        public List<EnemyBehaviour> EnemyBehaviours;
        
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

            EndTurn();
        }

        private void TakeEnemyTurns()
        {
            Vector3 playerPosition = PlayerController.Instance.transform.position;
            foreach (EnemyBehaviour enemy in EnemyBehaviours.OrderBy(x => Vector2.Distance(x.transform.position, playerPosition)))
            {
            }
        }

        private void SpawmEnemies()
        {

        }
    }
}