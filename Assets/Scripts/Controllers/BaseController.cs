using System.Collections;
using Managers;
using UnityEngine;

namespace Controllers
{
    public abstract class BaseController : MonoBehaviour
    {
        protected bool IsTurn { get; private set; }
        
        public virtual void StartTurn()
        {
            IsTurn = true;
        }

        protected void EndTurn()
        {
            IsTurn = false;
            TurnManager.Instance.NextTurn();
        }

        protected abstract IEnumerator WaitForEndOfTurn();
    }
}