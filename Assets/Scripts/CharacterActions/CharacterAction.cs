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
        [SerializeField] protected string _actionName;
        public string ActionName => _actionName;
        
        [SerializeField]
        protected ActionType _actionType = ActionType.None;
        public ActionType ActionType => _actionType;


        public abstract void ExecuteAction(params  object[] list);
    }
}