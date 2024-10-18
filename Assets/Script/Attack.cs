using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDamage = 10;
    public Vector2 knockback = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageble damageble = collision.GetComponent<Damageble>();

        if (damageble != null)
        {
            bool gotHit = damageble.Hit(attackDamage, knockback);

            if (gotHit)
                Debug.Log(collision.name + " hit for " + attackDamage);
        }
    }
}
