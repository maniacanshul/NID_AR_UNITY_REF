using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private AudioManager audioManager;

    private void Awake()
    {
        playerManager.SetupMyReferences(audioManager, enemyManager);
        enemyManager.SetupMyReferences(audioManager, playerManager);
        audioManager.SetupMyReferences(playerManager, enemyManager);
    }
}
