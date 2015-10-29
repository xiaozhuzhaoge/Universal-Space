using UnityEngine;
using System.Collections;

public class TryNavMeshAgent : MonoBehaviour {

    private NavMeshAgent nma;
    private Vector3 origin;
    public Transform ds;

	// Use this for initialization
	void Start () {
        nma = this.GetComponent<NavMeshAgent>();
        origin = transform.position;
	}
	
    void OnGUI()
    {
        if(GUILayout.Button("Start"))
        {
            nma.SetDestination(ds.position); 
        }
        if(GUILayout.Button("Stop"))
        {
            nma.Stop();
        }
        if(GUILayout.Button("Resume"))
        {
            nma.Resume();
        }
    }


	// Update is called once per frame
	void Update () {
	
	}
}
