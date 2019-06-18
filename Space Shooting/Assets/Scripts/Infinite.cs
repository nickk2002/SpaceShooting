using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinite : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject imagePrefab;
    private GameObject Canvas;
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        for (int i = 0; i <= 10; i++)
        {
            Vector3 position = new Vector3(imagePrefab.transform.localPosition.x, imagePrefab.transform.localPosition.y + imagePrefab.GetComponent<RectTransform>().rect.width * i, imagePrefab.transform.localPosition.z);
            GameObject image = Instantiate(imagePrefab);
            image.transform.SetParent(Canvas.transform, false);
            image.transform.localPosition = position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
