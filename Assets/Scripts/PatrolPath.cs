using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
public class PatrolPath : MonoBehaviour
{

    public List<GameObject> path;
    public int nextWaypoint;
    public float percentTomoveEachUpdate = 0.01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.transform.position = path[0].transform.position;
        nextWaypoint = 1;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position=Vector3.Lerp(this.transform.position, path[nextWaypoint].transform.position, percentTomoveEachUpdate);

        float distanceToWaypoint = (this.transform.position - path[nextWaypoint].transform.position).magnitude;
        if(distanceToWaypoint <=0.25f)
        {
            nextWaypoint++;
            if (nextWaypoint == path.Count) {
                nextWaypoint = 0;
            }
        }


    }
}
