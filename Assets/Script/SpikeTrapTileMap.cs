using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int damage = 50; // Amount of damage the spikes deal

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            Damageble damageable = other.GetComponent<Damageble>();
            if (damageable != null)
            {
                // Call the Hit method to apply damage
                damageable.Hit(damage, Vector2.zero); // You can adjust the knockback as needed
            }
        }
    }
}
