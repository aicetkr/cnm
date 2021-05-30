using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class script_n_aiControl : MonoBehaviour
{
    public NavMeshAgent nAgent;
    public CharacterController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update the agent destination to player
        nAgent.SetDestination(player.transform.position);
    }
}
