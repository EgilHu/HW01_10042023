using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectManager : MonoBehaviour
{
    public GameObject particleEffectPrefab;
    private int destroyedCubeObstacles = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CubeObstacle"))
        {
            Destroy(collision.gameObject); // 销毁碰撞到的CubeObstacle
            destroyedCubeObstacles++;

            if (destroyedCubeObstacles >= 6) // 当六个CubeObstacle都被销毁时
            {
                PlayParticleEffect();
            }
        }
    }

    private void PlayParticleEffect()
    {
        Instantiate(particleEffectPrefab, new Vector3(7.05999994f, 0.670000017f, 21.7600002f), Quaternion.identity);
    }
}
