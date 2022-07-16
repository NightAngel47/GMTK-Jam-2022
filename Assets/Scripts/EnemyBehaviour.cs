using System.Collections.Generic;
using CharacterActions;
using Controllers;
using Movement;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private EnemyMovement _enemyMovement;

    [SerializeField]
    private List<EnemyAction> _enemyActions;

    private void Awake()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    public void DoAction()
    {
        Vector2 dir = PlayerController.Instance.transform.position - transform.position;
                
        if (dir.magnitude <= 1)
        {
            // Attack
        }
        else
        {
            _enemyActions[0].ExecuteAction(dir, _enemyMovement);
        }
    }

    public bool IsDoneMoving()
    {
        return _enemyMovement.DoneMoving;
    }
}