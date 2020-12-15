using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    Enemy enemy;
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            Debug.Log("敵");
            enemy = col.gameObject.GetComponent<Enemy>();
            enemy.Damage();
        }
    }
}
