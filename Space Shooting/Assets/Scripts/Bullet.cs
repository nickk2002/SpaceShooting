using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float shootingSpeed = 30f;
    private Camera camera;  
    private GameObject Player;
    private Rigidbody2D rb;
    private float view;
    private Vector3 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        camera = Camera.main;
        direction = -Player.transform.up;
        view = camera.fieldOfView;
    }
    public void Shoot()
    {
        if (Player == null)
            return;
        rb.velocity = direction * shootingSpeed;
        if (transform.position.y >= Player.transform.position.y + 8)
        { 
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
}
