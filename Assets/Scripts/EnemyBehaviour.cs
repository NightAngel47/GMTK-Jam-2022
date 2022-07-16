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
            if (Mathf.Abs(dir.x) >= Mathf.Abs(dir.y))
                dir = new Vector2(Mathf.Sign(dir.x), 0f);
            else
                dir = new Vector2(0f, Mathf.Sign(dir.y));

            _enemyMovement.MoveEnemy(dir, 1);
        }
    }
}