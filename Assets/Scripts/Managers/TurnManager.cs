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
        public static TurnManager Instance { get; private set; }

        public Turns TurnState { get; private set; } = Turns.None;

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
            TurnState = Turns.PlayerTurn;
            PlayerController.Instance.StartTurn();
        }

        private void HandleEnemyTurn()
        {
            TurnState = Turns.EnemyTurn;
            EnemyController.Instance.StartTurn();
        }
    }
}