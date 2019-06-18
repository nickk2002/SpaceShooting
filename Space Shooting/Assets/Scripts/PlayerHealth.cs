using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform[] HealthIcons;
    private int lastIndex;
    private GameObject Player;
    void Start()
    {
        HealthIcons = new Transform[transform.childCount];
        lastIndex = 0;
        for(int i = 0; i < transform.childCount; i++)
        {
            HealthIcons[i] = transform.GetChild(i);
        }
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoseHealth()
    {   
        if(lastIndex == transform.childCount)
        {

            Player player = Player.GetComponent<Player>();
            player.Dead();
            return;
        }
        HealthIcons[lastIndex].gameObject.SetActive(false);
        lastIndex++;
        
    }
}
