using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name);

        if(collision.gameObject.name == "Ethan")
        {
            gameObject.SetActive( false);
            PlayerMovement.score++;
            Debug.Log(PlayerMovement.score);
        }
    }
}
