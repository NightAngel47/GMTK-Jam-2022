using Movement;
using UnityEngine;

namespace CharacterActions
{
    [CreateAssetMenu(fileName = "PlayerMovementAction", menuName = "ScriptableObjects/PlayerMovementAction", order = 1)]
    class PlayerMovementAction : PlayerAction
    {
        [SerializeField]
        private int _moveDistance = 1;
        
        /// <summary>
        /// Executes Player Movement.
        /// </summary>
        /// <param name="list">Object 0: Vector2 Direction, Object 1: EnemyMovement enemyMovement</param>
        public override void ExecuteAction(params object[] list)
        {
            PlayerMovement playerMovement = (PlayerMovement)list[1];
            playerMovement.MovePlayer((Vector2)list[0], _moveDistance);
        }
    }
}