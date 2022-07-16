using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }

        private void TakeEnemyTurns()
        {
            //Enemies take turns

            EndTurn();
        }
    }
}