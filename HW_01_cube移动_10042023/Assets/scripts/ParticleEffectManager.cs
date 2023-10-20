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
            Destroy(collision.gameObject); // ������ײ����CubeObstacle
            destroyedCubeObstacles++;

            if (destroyedCubeObstacles >= 6) // ������CubeObstacle��������ʱ
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
