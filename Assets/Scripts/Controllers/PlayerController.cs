using System.Collections;
using System.Collections.Generic;
using CharacterActions;
using Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers
{
    public class PlayerController : BaseController
    {
        public static PlayerController Instance { get; private set; }

        [SerializeField]
        private PlayerAction[] _playerActions = new PlayerAction[4];

        private PlayerMovement _playerMovement;
        private bool _hasTakenAction;
        
        private int _selectedActionIndex = -1;
        private Vector2 _selectedDirection = Vector2.zero;

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
            
            StartCoroutine(WaitForEndOfTurn());
        }

        protected override IEnumerator WaitForEndOfTurn()
        {
            yield return new WaitUntil(() => _hasTakenAction);
            
            yield return new WaitUntil(() => _playerMovement.DoneMoving);
            // add more things to wait for before ending turn
                
            EndTurn();
        }

        private void PreformAction()
        {
            // determine if we have both an action and direction picked
            if (_selectedActionIndex < 0 || !(_selectedDirection.magnitude > 0)) return;
            
            _hasTakenAction = true;

            // preform movement or attack action
            if (_playerActions[_selectedActionIndex].ActionType == ActionType.Movement)
            {
                _playerActions[_selectedActionIndex].ExecuteAction(_selectedDirection, _playerMovement);
            }
            else
            {
                // player attack
            }
                
            // reset selection
            _selectedActionIndex = -1;
            _selectedDirection = Vector2.zero;
        }

        // called by input and also UI buttons
        public void ActionSelection(int actionIndex)
        {
            if (!IsTurn || _hasTakenAction) return;
            
            _selectedActionIndex = actionIndex;
            Debug.Log($"Action: {_playerActions[_selectedActionIndex].ActionName} is selected");

            PreformAction();
        }

        // called by PlayerInput
        public void ActionDirectionInput(InputAction.CallbackContext context)
        {
            if (!context.performed || !IsTurn || _hasTakenAction) return;
            
            _selectedDirection = context.ReadValue<Vector2>();
            Debug.Log($"Action Dir: {_selectedDirection}");
            
            PreformAction();
        }

        // called by PlayerInput
        public void ActionOneInput(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                ActionSelection(0);
            }
        }

        // called by PlayerInput
        public void ActionTwoInput(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                ActionSelection(1);
            }
        }

        // called by PlayerInput
        public void ActionThreeInput(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                ActionSelection(2);
            }
        }

        // called by PlayerInput
        public void ActionFourInput(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                ActionSelection(3);
            }
        }
    }
}