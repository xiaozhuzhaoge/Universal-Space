using UnityEngine;
using System.Collections;

public class TryNavMeshAgent : MonoBehaviour {

    public static TryNavMeshAgent instance;

    private NavMeshAgent nma;
    private Vector3 origin;
    public Transform ds;
    public GunMechansium lib;
    public Collider co;
    public Transform Shell;
    public bool ShellFlag;
    public GameObject DeadEffect;
    public GameObject BreakEffect;

    void Awake()
    {
        instance = this;
    }
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
        GUILayout.Label("Distance " + lib.getDistance());
        GUILayout.Label("Angle " + lib.getAngle());
      
    }


	// Update is called once per frame
	void Update () {
        Break();
	}

    public void ActiveShell()
    {
        if (Shell == null)
            return;

        Debug.Log(ShellFlag);
        ShellFlag = !ShellFlag;
        Shell.gameObject.SetActive(ShellFlag);
    }

    public void Dead()
    {
        DeadEffect.SetActive(true);
        Destroy(this.gameObject, 2f);
    }

    public void Break()
    {
       BreakEffect.SetActive(ShipHUD.instance.HP < ShipHUD.instance.startHP * 0.5f);
    }
}
