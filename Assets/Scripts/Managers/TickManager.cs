using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class TickManager : MonoBehaviour
    {
        public static TickManager Instance = null;

        private bool _isPlayerTurn = true;
        public bool IsPlayerTurn => _isPlayerTurn;

        public UnityEvent TickEnemy = new UnityEvent();
        public UnityEvent TickPlayer = new UnityEvent();

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(this);
        }

        private void PlayerTickReceived()
        {
            _isPlayerTurn = false;
            TickEnemy?.Invoke();
        }

        private void EnemyTickReceived()
        {
            _isPlayerTurn = true;
            TickPlayer?.Invoke();
        }
    }
}