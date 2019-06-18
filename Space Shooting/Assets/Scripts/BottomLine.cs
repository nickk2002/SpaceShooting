using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomLine : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Health;
    void Start()
    {
        Health = GameObject.FindWithTag("Health UI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        SpriteRenderer sprite = obj.GetComponent<SpriteRenderer>();
        Enemy enemy = obj.GetComponent<Enemy>();

        if (enemy != null &&  sprite.enabled)
        {
            Debug.Log("Enemy tocuhed end line" + collision.gameObject);
            PlayerHealth health = Health.GetComponent<PlayerHealth>();
            Debug.Log(obj);
            Destroy(collision.gameObject);
            health.LoseHealth();
            
        }
    }
}
