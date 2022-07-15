using Controllers;
using UnityEngine;

namespace Managers
{
    public enum Turns
    {
        None = -1,
        PlayerTurn,
        EnemyTurn
    }
    
    public class TurnManager : MonoBehaviour
    {
        public static TurnManager Instance = null;
        public Turns TurnState { get; private set; } = Turns.None;

        private PlayerController _playerController;
        private EnemyController _enemyController;
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(this);
        }

        public void NextTurn()
        {
            switch (TurnState)
            {
                case Turns.None:
                    // go to player turn (likely first turn or problem lol)
                    TurnState = Turns.PlayerTurn;
                    NextTurn();
                    break;
                case Turns.PlayerTurn:
                    HandleEnemyTurn();
                    break;
                case Turns.EnemyTurn:
                    HandlePlayerTurn();
                    break;
            }
        }

        private void HandlePlayerTurn()
        {
            TurnState = Turns.EnemyTurn;
            _playerController.StartTurn();
        }

        private void HandleEnemyTurn()
        {
            TurnState = Turns.PlayerTurn;
            _enemyController.StartTurn();
        }
    }
}