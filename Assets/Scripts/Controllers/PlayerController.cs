using Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers
{
    public class PlayerController : BaseController
    {
        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        public void MovementInput(InputAction.CallbackContext context)
        {
            if (IsTurn && context.performed)
            {
                _playerMovement.MovePlayer(context.ReadValue<Vector2>(), UnityEngine.Random.Range(1, 7));
                EndTurn();
            }
        }
    }
}