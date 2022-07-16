using Movement;
using UnityEngine;

namespace CharacterActions
{
    [CreateAssetMenu(fileName = "EnemyMovementAction", menuName = "ScriptableObjects/EnemyMovementAction", order = 1)]
    public class EnemyMovementAction : EnemyAction
    {
        [SerializeField]
        private int _moveDistance = 1;
        
        public override void ExecuteAction(params object[] list)
        {
            Vector2 dir = (Vector2)list[0];
            dir = Mathf.Abs(dir.x) >= Mathf.Abs(dir.y) ? new Vector2(Mathf.Sign(dir.x), 0f) : new Vector2(0f, Mathf.Sign(dir.y));
            EnemyMovement eMove = (EnemyMovement)list[1];
            eMove.MoveEnemy(dir, _moveDistance);
        }
    }
}