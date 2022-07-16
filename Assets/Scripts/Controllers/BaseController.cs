using Managers;
using UnityEngine;

namespace Controllers
{
    public class BaseController : MonoBehaviour
    {
        protected bool IsTurn { get; private set; }

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