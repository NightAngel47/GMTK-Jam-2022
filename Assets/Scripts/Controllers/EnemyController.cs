using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class EnemyController : BaseController
    {
        public List<GameObject> EnemyGameObjects;

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