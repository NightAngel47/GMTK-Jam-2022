using System.Collections;
using Managers;
using UnityEngine;

namespace Controllers
{
    public abstract class BaseController : MonoBehaviour
    {
        protected bool IsTurn { get; private set; }
        
        public virtual IEnumerator StartTurn()
        {
            IsTurn = true;
            yield return null;
        }

        protected void EndTurn()
        {
            IsTurn = false;
            TurnManager.Instance.NextTurn();
        }
    }
}