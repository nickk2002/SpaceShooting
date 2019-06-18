using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{


    public enum AttackMode
    {
        Random,
        Wave
    }
    [SerializeField] private AttackMode attackMode;
    [SerializeField] private GameController.GameDifficulty difficulty;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float waveSpawnDelay;
    [SerializeField] private float attackModeDelay;

    private float spawnTime;
    private float waveSpawnTime;
    private float attackModeTime;

    private float diferenceY;
    private int multiplier = 1;

    private int numberRow;
    private int spawned = 0;


    private GameObject Player;
    private Vector3 spawnPosition;
    private WaveSpawner waveSpawner;
    private GameController.GameMode gamemode;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        diferenceY = enemyPrefab.transform.position.y - Player.transform.position.y;
        spawnPosition = enemyPrefab.transform.localPosition;
        gamemode = new GameController.GameMode();
        waveSpawner = GetComponent<WaveSpawner>();
        GameMode();

    }
    void GameMode()
    {
        if (difficulty == GameController.GameDifficulty.Easy)
            gamemode.mode = GameController.GameMode.Easy;
        if (difficulty == GameController.GameDifficulty.Medium)
            gamemode.mode = GameController.GameMode.Medium;
        if (difficulty == GameController.GameDifficulty.Hard)
            gamemode.mode = GameController.GameMode.Hard;
        if (difficulty == GameController.GameDifficulty.Insame)
        {
            attackModeTime = 0f;
            gamemode.mode = GameController.GameMode.Insane;
        }
        ChangeRowNumber();
    }

    void ChangeRowNumber()
    {
        numberRow = Random.Range(gamemode.mode.minNumberRow, gamemode.mode.maxNumberRow);
        Debug.Log(gamemode.mode.minNumberRow);
    }
    // Update is called once per frame
    IEnumerator EnemyPlace()
    {
        
        spawnPosition.x = enemyPrefab.transform.localPosition.x;
        spawnPosition.x += Random.Range(-10, 10);
        spawnPosition.y = Player.transform.position.y + diferenceY * multiplier;
        if(spawned + 1 > numberRow)
        {
            Debug.Log("Reached real Number" + numberRow);
            spawned = 0;
            ChangeRowNumber();
            multiplier++;
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
        if (spawnTime > spawnDelay && spawned == 0)
        {
            StartCoroutine(EnemyPlace());
            spawnTime = 0;
        }
        spawnTime += Time.deltaTime;
    }
    void PlaceWave()
    {
        if (waveSpawnTime > waveSpawnDelay || waveSpawnTime == 0)
        {
            waveSpawner.RandomState();
            waveSpawnTime = 0;
        }
        waveSpawnTime += Time.deltaTime;
    }
    void ChangeAttackMode()
    {
        if (attackMode == AttackMode.Random)
            attackMode = AttackMode.Wave;
        else
            attackMode = AttackMode.Random;
    }
    void GenerateEnemys()
    {
        if(gamemode.mode == GameController.GameMode.Insane)
        {
            if(attackModeTime >= attackModeDelay)
            {
                ChangeAttackMode();
                attackModeTime = 0;
            }
            attackModeTime += Time.deltaTime;
        }
        if (attackMode == AttackMode.Random)
            PlaceRandom();
        else if (attackMode == AttackMode.Wave)
            PlaceWave();
    }
    void Update()
    {
        GenerateEnemys();
    }
}
