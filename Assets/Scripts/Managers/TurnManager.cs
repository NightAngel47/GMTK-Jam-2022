using System;
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

        private void Start()
        {
            NextTurn(); // TODO remove temp for testing player
        }

        public void NextTurn()
        {
            switch (TurnState)
            {
                case Turns.None:
                    // go to player turn (likely first turn or problem lol)
                    TurnState = Turns.EnemyTurn;
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
            StartCoroutine(PlayerController.Instance.StartTurn());
            Debug.Log("Started Player Turn");
        }

        private void HandleEnemyTurn()
        {
            TurnState = Turns.EnemyTurn;
            StartCoroutine(EnemyController.Instance.StartTurn());
            Debug.Log("Started Enemy Turn");
        }
    }
}