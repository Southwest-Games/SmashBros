using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnCharacterController : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint1;

    [SerializeField]
    Transform spawnPoint2;

    [SerializeField]
    Transform spawnPoint3;

    [SerializeField]
    Transform spawnPoint4;

    [SerializeField]
    GameObject respawnPoint1;

    [SerializeField]
    GameObject respawnPoint2;

    [SerializeField]
    GameObject respawnPoint3;

    [SerializeField]
    GameObject respawnPoint4;

    [SerializeField]
    LivesController livesController;

    [SerializeField]
    BattleController battleController;

    public Action MakeAIJump;

    [SerializeField]
    GameObject marioObject;

    [SerializeField]
    GameObject bowserObject;

    [SerializeField]
    GameObject pikachuObject;

    [SerializeField]
    GameObject donkeyKongObject;

    [SerializeField]
    GameObject linkObject;

    [SerializeField]
    GameObject iceClimbersObject;

    [SerializeField]
    GameObject captainFalconObject;

    [SerializeField]
    GameObject samusObject;

    [SerializeField]
    GameObject sonicObject;

    int spawned;

    void Awake()
    {
        SpawnCharacter(GameState.P1_Character, spawnPoint1);
        SpawnCharacter(GameState.P2_Character, spawnPoint2);
        SpawnCharacter(GameState.P3_Character, spawnPoint3);
        SpawnCharacter(GameState.P4_Character, spawnPoint4);
    }

    void OnEnable()
    {
        livesController.RespawnCharacter += HandleRespawnCharacter;
    }

    void OnDisable()
    {
        livesController.RespawnCharacter += HandleRespawnCharacter;
    }

    void RespawnCharacter(GameObject go, GameObject respawnPoint, int damageResetPos, int playerNumber)
    {
        GameObject p = Instantiate(go, respawnPoint.transform.position, Quaternion.Euler(0, 0, 0));
        CharacterController characterController = p.GetComponent<CharacterController>();

        if(characterController != null)
        {
            characterController.enabled = true;
        }

        AICharacterController aiCharacterController = p.GetComponent<AICharacterController>();

        if(playerNumber == 1)
        {
            p.tag = "Player";

            if(aiCharacterController != null)
            {
                Destroy(aiCharacterController);
            }
        }
        else
        {
            p.tag = "AI";
            aiCharacterController.enabled = true;
        }

        Animator animator = p.GetComponent<Animator>();
        animator.enabled = true;

        p.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        battleController.ResetDamageAtPosition(damageResetPos);
        DamageResolver dmgResolver = p.GetComponent<DamageResolver>();
        if(dmgResolver != null)
        {
            dmgResolver.DoDamage += battleController.HandleApplyDamage;
        }
    }

    void HandleRespawnCharacter(GameObject go)
    {
        if(GameState.P1_Character.ToString() == go.name)
        {
            RespawnCharacter(go, respawnPoint1, 0, 1);
        }
        else if(GameState.P2_Character.ToString() == go.name)
        {
            RespawnCharacter(go, respawnPoint2, 1, 2);
        }
        else if(GameState.P3_Character.ToString() == go.name)
        {
            RespawnCharacter(go, respawnPoint3, 2, 3);
        }
        else if(GameState.P4_Character.ToString() == go.name)
        {
            RespawnCharacter(go, respawnPoint4, 3, 4);
        }
    }

    void SpawnCharacter(GameState.Character character, Transform spawnPoint)
    {
        if(character == GameState.Character.Bowser)
        {
            Instantiate(bowserObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.Mario)
        {
            Instantiate(marioObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.Link)
        {
            Instantiate(linkObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.Pikachu)
        {
            Instantiate(pikachuObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.Samus)
        {
            Instantiate(samusObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.IceClimbers)
        {
            Instantiate(iceClimbersObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.DonkeyKong)
        {
            Instantiate(donkeyKongObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.CaptainFalcon)
        {
            Instantiate(captainFalconObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (character == GameState.Character.Sonic)
        {
            Instantiate(sonicObject, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }

        spawned++;

        if(spawned == 4)
        {
            GameState.Init();
        }

    }
}
