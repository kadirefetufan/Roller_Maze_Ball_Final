using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour

{
        
    public Rigidbody _rb;
    private GameManager _gm;
    public Image _scoreBar;
    public float _moveSpeed;
    private Vector2 _firstPos;
    private Vector2 _secondPos;
    public Vector2 _currentPos;
    public float _currentGroundNumber;
    public Color colorx;
    private bool isFinish;

    //---
    [SerializeField] private BallColorSettings ballcolors;
    


    public Material ball1;
    public Material ball2;
    public Material ball3;

    public Material currentMaterial;

    //---
    void Start()
    {
        _gm = GameObject.FindObjectOfType<GameManager>();
        isFinish = false;                   
    }
    
    void Update()
    {
        Swipe();
        _scoreBar.fillAmount = _currentGroundNumber / _gm._groundNumbers;
        if (_scoreBar.fillAmount == 1 && !isFinish)
        {
            isFinish = true;
           _gm.LevelUpdate();
            
        }       
        gameObject.GetComponent<MeshRenderer>().material = currentMaterial;
    }
   
    private void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Debug.Log(_firstPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            _currentPos = new Vector2(
                _secondPos.x - _firstPos.x,
                _secondPos.y - _firstPos.y
            );

            _currentPos.Normalize();
        }
        if (_currentPos.y > 0 && _currentPos.x > -0.5f && _currentPos.x < 0.5f)
        {            
            _rb.velocity = Vector3.forward * _moveSpeed;
        }
        else if (_currentPos.y < 0 && _currentPos.x > -0.5f && _currentPos.x < 0.5f)
        {            
            _rb.velocity = Vector3.back * _moveSpeed;
        }
        else if (_currentPos.x > 0 && _currentPos.y > -0.5f && _currentPos.y < 0.5f)
        {            
            _rb.velocity = Vector3.right * _moveSpeed;
        }
        else if (_currentPos.x < 0 && _currentPos.y > -0.5f && _currentPos.y < 0.5f)
        {            
            _rb.velocity = Vector3.left * _moveSpeed;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<MeshRenderer>().material.color != colorx)
        {
            if (other.gameObject.tag == "Ground")
            {
                Constraints();
                other.gameObject.GetComponent<MeshRenderer>().material.color = colorx;
                _currentGroundNumber++;
            }
        }
    }

    private void Constraints()
    {
        _rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }


    public void ColorButton()
    {
        colorx = Color.white;
        currentMaterial = ball1;
    }
    public void ColorButton1()
    {        
        if(ballcolors.isBlueLock)
        {
            return;
        }
        else
        {
            currentMaterial = ball2;
            colorx = Color.blue;
        }
        
    }
    public void ColorButton2()
    {
        
        if (ballcolors.isYellowLock)
        {
            return;
        }
        else
        {
            currentMaterial = ball3;
            colorx = Color.yellow;
        }
    }
}

