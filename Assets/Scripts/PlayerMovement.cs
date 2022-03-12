using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animationPlayer;
    public GameObject player;
    public GameObject ball;
    public static int score;
    RaycastHit hit;
    int b = 0;
    int total;
    Text totalScore;
    Text remainingScore;

    List<Vector3> playerPosition = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animationPlayer = GetComponent<Animator>();
        totalScore = GameObject.Find("total").GetComponent<Text>();
        remainingScore = GameObject.Find("remaining").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


            if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            total = playerPosition.Count + 1;
            totalScore.text = total.ToString();
           
            if (Physics.Raycast(ray, out hit))
            {   
                //adding on click position in the list
                playerPosition.Add(hit.point);
                
                //creating object on runtime on mouse click
                ball.transform.position = hit.point;
                Instantiate(ball, ball.transform.position, ball.transform.rotation);
            }
           
        }

        if (player.transform.position.z == playerPosition[b].z)
        {
           /* Debug.Log("----Reached--------" + player.transform.position.z);
            Debug.Log("----Reached 2 = " + playerPosition[b].z + "--------");
            Debug.Log("---- value of B : " + b);*/

            animationPlayer.SetBool("Run", false);
            animationPlayer.SetBool("Idle", true);
            b++;
        }


        /*    if (player.transform.position.z == hit.point.z)
            {
               

            }
    */

            
/*
            if (playerPosition[b].z == player.transform.position.z)
            {
                b++;
            }
            Debug.Log("Player Index :" + playerPosition[b].z);*/
        
     
    }

    private void LateUpdate()
    {
        agent.SetDestination(playerPosition[b]);
        animationPlayer.SetBool("Run", true);
        animationPlayer.SetBool("Idle", false);
        remainingScore.text = (total - score).ToString();

    }


}
