using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class getName : MonoBehaviour
{
    public GameObject nameInputField;
     public TextMeshProUGUI errMsg;


    public string playerName;
    public void storeName()
    {
        playerName = nameInputField.GetComponent<Text>().text;

        if (string.IsNullOrEmpty(playerName) || playerName.Trim().Equals(""))
        {
            errMsg.GetComponent<TextMeshProUGUI>().text = Constants.errMsg;
            Debug.Log("Field is Empty");
        }
        else
        {

            errMsg.GetComponent<TextMeshProUGUI>().text = "";
            PlayerPrefs.SetString("Name", playerName);
            SceneManager.LoadScene(Constants.homebaseSceneIndex);
            Debug.Log(playerName);

        }
        

    }
}

