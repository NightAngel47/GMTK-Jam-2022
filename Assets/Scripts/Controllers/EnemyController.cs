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
        public List<GameObject> EnemyGameObjects;
        
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
            EnemyGameObjects.OrderBy(x => Vector2.Distance(x.transform.position, playerPosition));

            for (int index = 0; index < EnemyGameObjects.Count; index++)
            {
                Vector2 dir = playerPosition - EnemyGameObjects[index].transform.position;
                
                if (dir.magnitude <= 1)
                {
                    // Attack
                }
                else
                {
                    if (Mathf.Abs(dir.x) >= Mathf.Abs(dir.y))
                        dir = new Vector2(Mathf.Sign(dir.x), 0f);
                    else
                        dir = new Vector2(0f, Mathf.Sign(dir.y));

                    EnemyGameObjects[index].GetComponent<EnemyMovement>().MoveEnemy(dir, 1);
                }
            }
        }

        private void SpawmEnemies()
        {

        }
    }
}