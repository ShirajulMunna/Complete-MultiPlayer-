using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamSpawnmanager : MonoBehaviour
{
    public static TeamSpawnmanager instance;

    GameObject[] teamA;
    GameObject[] teamB;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        teamA = GameObject.FindGameObjectsWithTag("ATeam");
        teamB = GameObject.FindGameObjectsWithTag("BTeam");
    }

    public Transform GetSpawnPosition(int teamNumber)
    {
        if (teamNumber == 0)
        {
            return GetATeamPosition();
        }

        else 
        {
            return GetBTeamPosition();
        }
         
    }

    public Transform GetATeamPosition()
    {
        return teamA[Random.Range(0, teamA.Length)].transform;
    }

    public Transform GetBTeamPosition()
    {
        return teamB[Random.Range(0, teamB.Length)].transform;
    }
}
