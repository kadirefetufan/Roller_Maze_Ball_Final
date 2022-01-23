using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColors : MonoBehaviour
{

    [SerializeField] private BallColorSettings ballcolors;
    [SerializeField] private GameObject ball;


    public Material ball1;
    public Material ball2;
    public Material ball3;

    public Material currentMaterial;
    void Start()
    {
       // ball.GetComponent<MeshRenderer>().materials =
    }

    
    void Update()
    {
        
    }
}
