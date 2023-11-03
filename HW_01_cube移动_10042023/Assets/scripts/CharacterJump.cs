using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    private CharacterManager characterManager;

    private void Start()
    {
        //characterManager = CharacterManager.instance;
    }

    private void Update()
    {
        // ºÏ≤‚Ã¯‘æ ‰»Î
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    characterManager.JumpCharacter();
        //}
        CharacterManager.instance.JumpCharacter();
        CharacterManager.instance.ReachGround = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            CharacterManager.instance.ReachGround = true;
        }
    }
}
