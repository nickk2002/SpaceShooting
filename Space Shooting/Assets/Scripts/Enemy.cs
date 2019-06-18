using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    // Start is called before the first frame update
    public bool touched = false;
    public float health = 100f;
    public bool destroyed = false;
    private SpriteRenderer sprite;
    private Scor scor;
    private Animator animator;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        scor = GameObject.Find("Scor").GetComponent<Scor>();
    }
    IEnumerator ChangeColor()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(1.5f);
        sprite.color = Color.white;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            touched = true;
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Was hit");
            health -= 50f;
            StartCoroutine(ChangeColor());
            if (health <= 0)
            {
                destroyed = true;
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<BoxCollider2D>());
                StartCoroutine(Remove());
                scor.Add();
            }
            Destroy(collision.gameObject);  
        }
    }
    IEnumerator Remove()
    {
        animator.SetBool("expl", true);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
