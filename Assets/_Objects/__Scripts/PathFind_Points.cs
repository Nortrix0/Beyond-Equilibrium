using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(PathFind))]
public class PathFind_Points : MonoBehaviour {
    public Transform[] Points;
//    List<Vector3> _Points;
    NavMeshAgent agent;
    [SerializeField] bool Backtrack;
    PathFind PF;
    [SerializeField] int Point = 0;
    bool Backwards = false;
    [SerializeField]
    float dis;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
        PF = GetComponent<PathFind>();
        PF.OVRDest = true;
        agent.SetDestination(Points[0].position);
	}

    void FixedUpdate()
    {
        //test = transform.position + " " + Points[Point].position.ToString();
        Debug.DrawLine(transform.position, agent.destination, Color.black);
        dis = Vector3.Distance(transform.position, Points[Point].position);
        if (Backtrack)
        {
            if (Point == Points.Length - 1) { Backwards = true; }
            if (Point == 0) { Backwards = false; }
            if (dis <= 0.5f)
            {
                if (Backwards)
                {
                    Point--;
                }
                else
                {
                    Point++;
                }
                agent.SetDestination(Points[Point].position);
            }
        }
        else
        {
            if (dis <= 0.5f)
            {
                Point++;
                if(Point == Points.Length){
                    Point = 0;
                }
                agent.SetDestination(Points[Point].position);
            }
        }
        if(PF.FoundPlayer){
            PF.OVRDest = false;
        }
	}
}
