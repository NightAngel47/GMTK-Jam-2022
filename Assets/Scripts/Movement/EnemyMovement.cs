using System.Collections;
using UnityEngine;

namespace Movement
{
    public class EnemyMovement : CharacterMovement
    {
        public void MoveEnemy(Vector3 direction, int distance)
        {
            MoveCharacter(direction, distance);
        }
    }
}