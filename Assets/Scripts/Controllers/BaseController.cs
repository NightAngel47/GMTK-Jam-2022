using Managers;
using UnityEngine;

namespace Controllers
{
    public class BaseController : MonoBehaviour
    {
        public static BaseController Instance { get; private set; }
        
        protected bool IsTurn { get; private set; }
        
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
        
        public void StartTurn()
        {
            IsTurn = true;
        }

        protected void EndTurn()
        {
            IsTurn = false;
            TurnManager.Instance.NextTurn();
        }
    }
}