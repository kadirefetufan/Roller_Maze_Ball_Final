using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] _grounds;
    public float _groundNumbers;
    private int _currentLevel;

    public GameObject _nextLevelUI;
    public GameObject _extLevelUI;


    [SerializeField] private LevelHolderSettings LevelHolders;
    void Start()
    {
        _nextLevelUI.SetActive(false);
        _extLevelUI.SetActive(true);

        _grounds = GameObject.FindGameObjectsWithTag("Ground");
        _currentLevel = SceneManager.GetActiveScene().buildIndex;

       // Debug.Log("Number of Grounds: " + _grounds.Length);  

    }


    void Update()
    {
        _groundNumbers = _grounds.Length;
    }

    public void LevelUpdate()
    {
        _nextLevelUI.SetActive(true);
        _extLevelUI.SetActive(false);
        LevelHolders.level++;
        LevelHolders.gift++;

        if(LevelHolders.gift > 3)
        {
            LevelHolders.gift = 4;
        }

    }
}
