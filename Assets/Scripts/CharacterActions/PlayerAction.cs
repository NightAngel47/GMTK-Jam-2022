using UnityEngine;

namespace CharacterActions
{
    abstract class PlayerAction : CharacterAction
    {
        [SerializeField]
        protected int ActionRisk;
    }
}