using System;
using System.Collections;
using Movement;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class PlayerController : BaseController
    {
        public static PlayerController Instance { get; private set; }
        
        private PlayerMovement _playerMovement;
        private bool _hasTakenAction;

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
            
            _playerMovement = GetComponent<PlayerMovement>();
        }
        
        public override void StartTurn()
        {
            base.StartTurn();
            _hasTakenAction = false;
        }

        public void MovementInput(InputAction.CallbackContext context)
        {
            if (IsTurn && !_hasTakenAction && context.performed)
            {
                _hasTakenAction = true;
                int distance = Random.Range(1, 7);
                _playerMovement.MovePlayer(context.ReadValue<Vector2>(), distance);
                Debug.Log($"Player is moving {distance} units.");

                StartCoroutine(WaitForActionToEnd());
            }
        }

        private IEnumerator WaitForActionToEnd()
        {
            if (_hasTakenAction)
            {
                yield return new WaitUntil(() => _playerMovement.DoneMoving);
                
                EndTurn();
            }
            
            yield return null;
        }
    }
}