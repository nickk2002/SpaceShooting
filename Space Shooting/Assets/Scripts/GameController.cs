using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public enum GameDifficulty
    {
        Easy,
        Medium,
        Hard,
        Insame
    }
    public class GameModeInfo
    {

        public float spawnDelay;
        public int minNumberRow,maxNumberRow; 
        public GameModeInfo(float _spawnDelay, int min,int max)
        {
            minNumberRow = min;
            maxNumberRow = max;
        }
    }
    public class GameMode
    {
        static public GameModeInfo Easy, Medium, Hard, Insane;
        public GameModeInfo mode;
        public GameMode()
        {
            Easy = new GameModeInfo(1f,0,3);
            Medium = new GameModeInfo(0.5f,1,3);
            Hard = new GameModeInfo(0.25f,3,6);
            Insane = new GameModeInfo(0.25f,4,10);
        }
        GameMode(GameModeInfo _mode)
        {
            mode = _mode;
        }
    }

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
}

