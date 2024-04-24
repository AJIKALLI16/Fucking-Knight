using System.Collections;
using UnityEngine;


public class Player_attack : MonoBehaviour
{
    public Animator anim;
    public bool Attack = false;
    public GameObject attackhitbox;
    void Start()
    {
        anim = GetComponent<Animator>();
        attackhitbox.SetActive(false);
    }

    void Update()
    {
        attacknomove();
    }
    void attacknomove()
    {
        if (Input.GetKey(KeyCode.C) && !Attack)
        {
            Attack = true;
            anim.SetBool("Attack", Attack);
            StartCoroutine(DoAttack());
        }
    }
    IEnumerator DoAttack()
    {
        attackhitbox.SetActive (true);
        yield return new WaitForSeconds(0.5f);
        attackhitbox.SetActive (false);
        Attack = false;
        anim.SetBool("Attack", Attack);
    }
}
