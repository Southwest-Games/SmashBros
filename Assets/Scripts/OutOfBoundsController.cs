using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OutOfBoundsController : MonoBehaviour
{
    public Action<GameState.Character> RemoveLife;
    GameState.Character tempCharacter;

    void OnTriggerEnter(Collider col)
    {
        switch(col.gameObject.name)
        {
            case "Bowser":
                tempCharacter = GameState.Character.Bowser;
                break;
            case "Mario":
                tempCharacter = GameState.Character.Mario;
                break;
            case "Link":
                tempCharacter = GameState.Character.Link;
                break;
            case "Samus":
                tempCharacter = GameState.Character.Samus;
                break;
            case "DonkeyKong":
                tempCharacter = GameState.Character.DonkeyKong;
                break;
            case "IceClimbers":
                tempCharacter = GameState.Character.IceClimbers;
                break;
            case "Pikachu":
                tempCharacter = GameState.Character.Pikachu;
                break;
            case "CaptainFalcon":
                tempCharacter = GameState.Character.CaptainFalcon;
                break;
            case "Sonic":
                tempCharacter = GameState.Character.Sonic;
                break;
        }

        if(tempCharacter != null)
        {
            RemoveLife?.Invoke(tempCharacter);
        }

        if(col.gameObject != null)
        {
            Destroy(col.gameObject);
        }
    }
}
