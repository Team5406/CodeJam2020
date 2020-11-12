using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getName : MonoBehaviour
{
    public GameObject nameInputField;


    public string playerName;
    public void storeName()
    {
        playerName = nameInputField.GetComponent<Text>().text;
        PlayerPrefs.SetString("Name", playerName);
        Debug.Log(playerName);

    }
}

