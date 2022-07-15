using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TickManager : MonoBehaviour
{
    public static TickManager Instance = null;

    private bool isPlayerTurn = true;
    public bool IsPlayerTurn => isPlayerTurn;

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
        isPlayerTurn = false;
        TickEnemy?.Invoke();
    }

    private void EnemyTickReceived()
    {
        isPlayerTurn = true;
        TickPlayer?.Invoke();
    }
}