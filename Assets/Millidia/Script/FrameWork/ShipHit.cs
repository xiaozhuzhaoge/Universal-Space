using UnityEngine;
using System.Collections;

public class ShipHit : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        ShipHUD.instance.OnHit(Random.Range(1, 40));
    }

   
}
