using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private GameObject fireBallPrefab;
    [SerializeField] private GameObject fireBallPosisiton;
    [SerializeField] private float shootingDelay = 1f;
    [SerializeField] private bool isAuto = false;

    private float shootingTime;
    void Start()
    {

    }
    void OneShoot()
    {
        GameObject bullet = Instantiate(fireBallPrefab);
        bullet.transform.localScale = fireBallPrefab.transform.localScale;
        bullet.transform.position = fireBallPosisiton.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (isAuto)
            shootingDelay = 1.5f;
        else
            shootingDelay = 0.1f;
        if (Input.GetKeyDown(KeyCode.E))
            isAuto = !isAuto;
        if(isAuto && shootingTime >= shootingDelay)
        {
            shootingTime = 0;
            OneShoot();
        }
        if (Input.GetKeyDown(KeyCode.Space) && shootingTime >= shootingDelay && !isAuto)
        {
            OneShoot();
            shootingTime = 0f;
        }
        shootingTime += Time.deltaTime;

    }
}
