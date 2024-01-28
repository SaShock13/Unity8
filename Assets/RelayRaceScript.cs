using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayRaceScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] runners;
    [SerializeField]
    GameObject finishFlag;
    [SerializeField]
    GameObject stick;    
    Vector3 finish;
    [SerializeField]
    float speed;

    Vector3 targetPosition;
    GameObject currentRunner;    
    float offset;
    int runnerIndex=0;
    bool isFinished;
    
    
    Vector3 runnerPosition;
    
    void Start()
    {
        finish= Vector3.zero;
        offset = 1;        
        currentRunner = runners[runnerIndex];
        targetPosition = runners[runnerIndex+1].transform.position;
        runners[runnerIndex + 1].transform.LookAt(currentRunner.transform);
    }
    
    void Update()
    {
        runnerPosition = currentRunner.transform.position;
        float distance=Vector3.Distance(runnerPosition,targetPosition);
        if (!isFinished)
        {
            Run();
        }        
        if (distance<=offset)
        {
            ChangeRunner();
        }
        if (runnerPosition == finish)
        {
            Finish();
        }
    }

    void Run()
    {
        currentRunner.transform.position = Vector3.MoveTowards(runnerPosition, targetPosition, speed * Time.deltaTime);
    }

    void ChangeRunner()
    {
        if (runnerIndex >= runners.Length - 2)
        {
            currentRunner = runners[runners.Length - 1];
            targetPosition = finish;
        }
        else
        {
            currentRunner = runners[++runnerIndex];
            targetPosition = runners[runnerIndex + 1].transform.position;
        }
        currentRunner.transform.LookAt(targetPosition);
        runners[runnerIndex + 1].transform.LookAt(currentRunner.transform);
        stick.transform.SetParent(currentRunner.transform);
        stick.transform.localPosition = new Vector3(0.35f, 0.5f, 0.6f);        
    }

    void Finish()
    {
        isFinished = true;
        finishFlag.active = true;
    }
}
