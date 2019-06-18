using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{



    [SerializeField] private GameController.GameMode gamemode;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDelay;
    private float spawnTime;
    private float diferenceY;
    private int numberOnRow,realNumber;

    [SerializeField] private float waveSpawnDelay;
    private float waveSpawnTime;
    private GameObject Canvas,Player;
    private int spawned = 0;
    private Vector3 spawnPosition;
    private WaveSpawner waveSpawner;
    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.Find("Player");
        diferenceY = enemyPrefab.transform.position.y - Player.transform.position.y;
        spawnPosition = enemyPrefab.transform.localPosition;
        gamemode = new GameController.GameMode
        {
            mode = GameController.GameMode.Easy
        };
        waveSpawner = GetComponent<WaveSpawner>();
        ChangeNumber();
    }

    void ChangeNumber()
    {
        realNumber = Random.Range(gamemode.mode.minNumberRow, gamemode.mode.maxNumberRow);
        Debug.Log(gamemode.mode.minNumberRow);
    }
    // Update is called once per frame
    IEnumerator EnemyPlace()
    {
        
        spawnPosition.x = enemyPrefab.transform.localPosition.x;
        spawnPosition.x += Random.Range(-10, 10);
        if(spawned + 1 > realNumber)
        {
            Debug.Log("Reached real Number" + realNumber);
            spawned = 0;
            ChangeNumber();
            spawnPosition.y += diferenceY;
        }
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.GetComponent<SpriteRenderer>().enabled = false;
        enemy.transform.SetParent(this.transform, false);
        enemy.transform.position = spawnPosition;
        spawnTime = 0;
        yield return new WaitForFixedUpdate();
        if (enemy.GetComponent<Enemy>().touched)
        {
            Destroy(enemy);
        }
        else
        {
            enemy.GetComponent<SpriteRenderer>().enabled = true;
            spawned++;
        }
    }
    void PlaceRandom()
    {
        if (spawnTime > spawnDelay)
        {
            StartCoroutine(EnemyPlace());
            spawnTime = 0;
        }
        spawnTime += Time.deltaTime;
    }
    void PlaceWave()
    {
        if (waveSpawnTime > waveSpawnDelay)
        {
            waveSpawner.RandomState();
            waveSpawnTime = 0;
        }
        waveSpawnTime += Time.deltaTime;
    }
    void Update()
    {
        PlaceRandom();
    }
}
