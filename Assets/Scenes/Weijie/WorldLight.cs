using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal; 

public class WorldLight : MonoBehaviour
{
    [SerializeField] private Gradient lightColor;
    [SerializeField] private GameObject theLight;

    private void Awake()
    {
        
    }
    private void Update()
    {
    }
}

