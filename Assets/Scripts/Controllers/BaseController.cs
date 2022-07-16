using Managers;
using UnityEngine;

namespace Controllers
{
    public class BaseController : MonoBehaviour
    {
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
        
        public virtual void StartTurn()
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