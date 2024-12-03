using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDamage = 10;
    public Vector2 knockback = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageble damageble = collision.GetComponent<Damageble>();

        if (damageble != null)
        {
            // Ki?m tra xem transform.parent c� null kh�ng tr??c khi s? d?ng
            Vector2 deliveredKnockback = (transform.parent != null && transform.parent.localScale.x > 0)
                ? knockback
                : new Vector2(-knockback.x, knockback.y);

            bool gotHit = damageble.Hit(attackDamage, deliveredKnockback);

            if (gotHit)
            {
                Debug.Log(collision.name + " hit for " + attackDamage);
            }
        }
        else
        {
            Debug.LogWarning("Collider does not have a Damageble component: " + collision.name);
        }
    }
}