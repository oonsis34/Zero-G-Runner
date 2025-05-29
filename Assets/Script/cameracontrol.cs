using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    public CinemachineVirtualCamera camPlayer; 
    public CinemachineVirtualCamera camEnemy;  
    public float enemyFocusTime = 3f;          

    public EnemyChase enemyChase; 
    public SideScrollRun playerMovement; 

    void Start()
    {
        StartCoroutine(SwitchToEnemyAndBack());
    }

    IEnumerator SwitchToEnemyAndBack()
    {
        
        if (enemyChase != null)
        {
            enemyChase.enabled = false;
        }
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        
        camPlayer.Priority = 0;
        camEnemy.Priority = 1;

        
        yield return new WaitForSeconds(enemyFocusTime);

        
        camPlayer.Priority = 1;
        camEnemy.Priority = 0;

        
        if (enemyChase != null)
        {
            enemyChase.enabled = true;
        }
        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }
    }
}
