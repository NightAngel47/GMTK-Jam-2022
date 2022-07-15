using UnityEngine;

namespace Movement
{
    public class PlayerMovement : CharacterMovement
    {
        public void MovePlayer(Vector3 direction, int distance)
        {
            MoveCharacter(direction, distance);
        }
    }
}