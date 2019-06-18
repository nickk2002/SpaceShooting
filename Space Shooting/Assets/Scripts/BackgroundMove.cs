using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float backgroundSpeed = 0.5f;
    private float maxTime = 30f,time;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 add = new Vector3(0, backgroundSpeed, 0);
        transform.position += add;
        backgroundSpeed += 0.00000001f;
    }
}
