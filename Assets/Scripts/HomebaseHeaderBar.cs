using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class HomebaseHeaderBar : MonoBehaviour
{


    //Some Variables
    bool isMute;
    float pastVolume;

    //Audio Mixer
    public AudioMixer audioMixer;

    //Homebase 
    public HomebaseStart adventures;
    public Homebase homebase;

    //THE TEXT FIELDS!!!
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerScore;
    public TextMeshProUGUI adventuresRemaining;
    public TextMeshProUGUI timeLeft;
    public TextMeshProUGUI fuel;

    //THE TOGGLE!!!!
    public Toggle muteToggle;

    //some sprites ig
    public Sprite soundON;
    public Sprite soundOFF;



    void Start()
    {
        playerName.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("Name");
    }

    
    void Update()
    {
        playerScore.GetComponent<TextMeshProUGUI>().text = "Score: " + homebase.playerScore.ToString();
        adventuresRemaining.GetComponent<TextMeshProUGUI>().text = "Adventures Remaining " + homebase.adventuresRemaining.ToString();
        timeLeft.GetComponent<TextMeshProUGUI>().text = 
        fuel.GetComponent<TextMeshProUGUI>().text = "Fuel: " + homebase.fuel.ToString();
        
    }


   public void muteVolume()
    {
        isMute = false;
        if (!isMute)
        {
            pastVolume = PlayerPrefs.GetFloat("masterVolume");
            isMute = true;
            audioMixer.SetFloat(Constants.masterAudioMixer, Constants.muteVolume);
            Debug.Log(Constants.muteVolume);
        }
        else if (isMute)
        {
            isMute = false;
            audioMixer.SetFloat(Constants.masterAudioMixer, pastVolume);
            Debug.Log(pastVolume);
        }
        
    }
}
