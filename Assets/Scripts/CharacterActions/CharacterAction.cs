using Unity.VisualScripting;
using UnityEngine;

namespace CharacterActions
{

    public enum ActionType
    {
        None = -1,
        Movement,
        Attack
    }
    
    //[CreateAssetMenu(fileName = "CharacterAction", menuName = "ScriptableObjects/CharacterActions", order = 1)]
    public abstract class CharacterAction : ScriptableObject
    {
        [SerializeField]
        private ActionType _actionType = ActionType.None;

        public abstract void ExecuteAction(params  object[] list);
    }
}