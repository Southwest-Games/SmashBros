using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class LivesController : MonoBehaviour
{
    int p1Lives;
    int p2Lives;
    int p3Lives;
    int p4Lives;

    [SerializeField]
    List<GameObject> p1LivesList;

    [SerializeField]
    List<GameObject> p2LivesList;

    [SerializeField]
    List<GameObject> p3LivesList;

    [SerializeField]
    List<GameObject> p4LivesList;

    [SerializeField]
    Sprite mario;

    [SerializeField]
    Sprite bowser;

    [SerializeField]
    Sprite pikachu;

    [SerializeField]
    Sprite donkeyKong;

    [SerializeField]
    Sprite link;

    [SerializeField]
    Sprite iceClimbers;

    [SerializeField]
    Sprite captainFalcon;

    [SerializeField]
    Sprite samus;

    [SerializeField]
    Sprite sonic;

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

    [SerializeField]
    OutOfBoundsController outOfBoundsController1;

    [SerializeField]
    OutOfBoundsController outOfBoundsController2;

    [SerializeField]
    OutOfBoundsController outOfBoundsController3;

    [SerializeField]
    OutOfBoundsController outOfBoundsController4;

    public Action<GameObject> RemoveCharacterFromAIList;
    public Action<GameObject> RespawnCharacter;
    public Action<int> RemoveDamageTextAtIndex;

    void Start()
    {
        p1Lives = GameState.lives;
        p2Lives = GameState.lives;
        p3Lives = GameState.lives;
        p4Lives = GameState.lives;

        InitializeLivesForCharacter(p1Lives, p1LivesList, GameState.P1_Character);
        InitializeLivesForCharacter(p2Lives, p2LivesList, GameState.P2_Character);
        InitializeLivesForCharacter(p3Lives, p3LivesList, GameState.P3_Character);
        InitializeLivesForCharacter(p4Lives, p4LivesList, GameState.P4_Character);
    }

    void OnEnable()
    {
        outOfBoundsController1.RemoveLife += HandleRemoveLife;
        outOfBoundsController2.RemoveLife += HandleRemoveLife;
        outOfBoundsController3.RemoveLife += HandleRemoveLife;
        outOfBoundsController4.RemoveLife += HandleRemoveLife;
    }

    void OnDisable()
    {
        outOfBoundsController1.RemoveLife -= HandleRemoveLife;
        outOfBoundsController2.RemoveLife -= HandleRemoveLife;
        outOfBoundsController3.RemoveLife -= HandleRemoveLife;
        outOfBoundsController4.RemoveLife -= HandleRemoveLife;
    }

    void Update()
    {
        if(GameState.winners.Count == 1)
        {
            SceneManager.LoadSceneAsync("CelebrationScreen");
        }
    }

    void InitializeLivesForCharacter(int lives, List<GameObject> characterLives, GameState.Character character)
    {
        foreach(GameObject go in characterLives)
        {
            if (character == GameState.Character.Bowser)
            {
                SetSprite(go, bowser);
            }
            else if(character == GameState.Character.Mario)
            {
                SetSprite(go, mario);
            }
            else if (character == GameState.Character.Link)
            {
                SetSprite(go, link);
            }
            else if (character == GameState.Character.Pikachu)
            {
                SetSprite(go, pikachu);
            }
            else if (character == GameState.Character.Samus)
            {
                SetSprite(go, samus);
            }
            else if (character == GameState.Character.IceClimbers)
            {
                SetSprite(go, iceClimbers);
            }
            else if (character == GameState.Character.DonkeyKong)
            {
                SetSprite(go, donkeyKong);
            }
            else if (character == GameState.Character.CaptainFalcon)
            {
                SetSprite(go, captainFalcon);
            }
            else if (character == GameState.Character.Sonic)
            {
                SetSprite(go, sonic);
            }

            go.SetActive(false);
        }

        for(int i = 0; i < lives; i++)
        {
            characterLives[i].SetActive(true);
        }
    }

    void SetSprite(GameObject go, Sprite sprite)
    {
        Image img = go.GetComponent<Image>();
        if(img != null)
        {
            img.sprite = sprite;
        }
    }

    void HandleRemoveLife(GameState.Character character)
    {
        if(character == GameState.P1_Character)
        {
            p1Lives--;

            if(p1Lives > 0)
            {
                p1LivesList[p1Lives].SetActive(false);
                GameObject newChar = GetGameObjectForCharacter(GameState.P1_Character);
                if(newChar != null)
                {
                    RespawnCharacter?.Invoke(newChar);
                }
            }
            else
            {
                p1LivesList[0].SetActive(false);
                RemoveCharacterFromAIList?.Invoke(GameState.P1);
                GameState.winners.Remove(GameState.P1_Character.ToString());
                RemoveDamageTextAtIndex?.Invoke(0);
            }
        }
        else if(character == GameState.P2_Character)
        {
            p2Lives--;

            if (p2Lives > 0)
            {
                p2LivesList[p2Lives].SetActive(false);
                GameObject newChar = GetGameObjectForCharacter(GameState.P2_Character);
                if (newChar != null)
                {
                    RespawnCharacter?.Invoke(newChar);
                }
            }
            else
            {
                p2LivesList[0].SetActive(false);
                RemoveCharacterFromAIList?.Invoke(GameState.P2);
                GameState.winners.Remove(GameState.P2_Character.ToString());
                RemoveDamageTextAtIndex?.Invoke(1);
            }
        }
        else if (character == GameState.P3_Character)
        {
            p3Lives--;

            if (p3Lives > 0)
            {
                p3LivesList[p3Lives].SetActive(false);
                GameObject newChar = GetGameObjectForCharacter(GameState.P3_Character);
                if (newChar != null)
                {
                    RespawnCharacter?.Invoke(newChar);
                }
            }
            else
            {
                p3LivesList[0].SetActive(false);
                RemoveCharacterFromAIList?.Invoke(GameState.P3);
                GameState.winners.Remove(GameState.P3_Character.ToString());
                RemoveDamageTextAtIndex?.Invoke(2);
            }
        }
        else if (character == GameState.P4_Character)
        {
            p4Lives--;

            if (p4Lives > 0)
            {
                p4LivesList[p4Lives].SetActive(false);
                GameObject newChar = GetGameObjectForCharacter(GameState.P4_Character);
                if (newChar != null)
                {
                    RespawnCharacter?.Invoke(newChar);
                }
            }
            else
            {
                p4LivesList[0].SetActive(false);
                RemoveCharacterFromAIList?.Invoke(GameState.P4);
                GameState.winners.Remove(GameState.P4_Character.ToString());
                RemoveDamageTextAtIndex?.Invoke(3);
            }
        }
    }

    private GameObject GetGameObjectForCharacter(GameState.Character character)
    {
        if(character == GameState.Character.Bowser)
        {
            return bowserObject;
        }
        else if(character == GameState.Character.Mario)
        {
            return marioObject;
        }
        else if(character == GameState.Character.Link)
        {
            return linkObject;
        }
        else if(character == GameState.Character.Pikachu)
        {
            return pikachuObject;
        }
        else if(character == GameState.Character.Samus)
        {
            return samusObject;
        }
        else if(character == GameState.Character.IceClimbers)
        {
            return iceClimbersObject;
        }
        else if(character == GameState.Character.DonkeyKong)
        {
            return donkeyKongObject;
        }
        else if(character == GameState.Character.CaptainFalcon)
        {
            return captainFalconObject;
        }
        else if(character == GameState.Character.Sonic)
        {
            return sonicObject;
        }
        else
        {
            Debug.Log("Something is wrong....");
            return null;
        }
    }
}
