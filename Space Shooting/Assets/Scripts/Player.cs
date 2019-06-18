using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Shooting))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private IEnumerator Remove()
    {
        animator.SetBool("expl", true);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        Destroy(this.gameObject);
    }
    public void Dead()
    {
        Debug.Log("DEAD");
        StartCoroutine(Remove());
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
