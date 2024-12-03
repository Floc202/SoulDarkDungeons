using Assets.Script;
using UnityEngine;

public class LavaFloor : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }


}