using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scor : MonoBehaviour
{
    // Start is called before the first frame update
    private Text text;
    int number = 0;

    void Start()
    {
        text = GetComponent<Text>();
    }
    public void Add()
    {
        number++;
    }
   
    // Update is called once per frame
    void Update()
    {
        text.text = "Scor : " + number;
    }
}
