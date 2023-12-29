using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private AudioManager audioManager;
    private EnemyManager enemyManager;

    public void SetupMyReferences(AudioManager am, EnemyManager em)
    {
        audioManager = am;
    }

    private void Start()
    {
        audioManager.PlayPlayerSpawnAudio();
    }
}
