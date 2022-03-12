using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animator animationPlayer;

    // Start is called before the first frame update
    void Start()
    {
        animationPlayer = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animationPlayer.SetBool("Run", true);
            animationPlayer.SetBool("Idle", false);

        }
       

    }
}
