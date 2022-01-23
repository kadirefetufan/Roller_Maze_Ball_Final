using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHolder : MonoBehaviour
{
    [SerializeField] private LevelHolderSettings LevelHolders;
    [SerializeField] private MenuScript MenuScripts;
    [SerializeField] private BallColorSettings BallColorSettings;


    public GameObject _giftIU1;
    public GameObject _giftIU2;    
    public GameObject _ballx;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _giftIU1.SetActive(true);
        _giftIU2.SetActive(false);        
       

    }

    void Update()
    {
       
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + LevelHolders.level);
        if ( LevelHolders.level > 5)
        {
            LevelHolders.level = 1;
        }

    }
    public void Giftbutton()
    {
        if ( LevelHolders.gift > 2)
        {
            _giftIU1.SetActive(false);
            _ballx.SetActive(false);
            _giftIU2.SetActive(true);
            BallColorSettings.isBlueLock = false;
        }

    }   
}
