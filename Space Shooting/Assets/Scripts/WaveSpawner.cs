using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaveSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private int state,maxState = 2;
    private Camera camera;
    private List<GameObject> Waves;
   
    void Start()
    {
        camera = Camera.main;
        Waves = new List<GameObject>();
        Waves = Resources.LoadAll("Waves", typeof(GameObject)).Cast<GameObject>().ToList();
        state = 0;
    }
    private void Show()
    {  
        GameObject prefab = Waves[state];
        Vector3 position = prefab.transform.position;
        position.y += camera.transform.position.y;
        GameObject obj = Instantiate(prefab);
        obj.transform.position = position;  
    }
    public void RandomState()
    {
        state = Random.Range(0, maxState);
        Debug.Log(state);
        Show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
