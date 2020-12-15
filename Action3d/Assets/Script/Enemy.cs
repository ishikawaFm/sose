using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 100;
    public Animator EnemyAnimator;

    public Player Player = null;
    // Start is called before the first frame update
    void Start()
    {
        EnemyAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (hp <= 0)
        {
            EnemyAnimator.SetTrigger("Die");
        }
    }

    void EnemyDie()
    {
        Destroy(gameObject);
    }



    public void Damage()
    {
        hp -= Player.attakDamage;
        Debug.Log(hp);
    }
    
}
