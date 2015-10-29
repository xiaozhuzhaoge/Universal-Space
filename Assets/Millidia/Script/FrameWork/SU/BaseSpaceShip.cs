
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BaseSpaceShip : MonoBehaviour {
	
	// Array of thrusters attached to the spaceship
	public Thruster[] thrusters;
	// Specify the roll rate (multiplier for rolling the ship when steering left/right)	
	public float rollRate = 100.0f;
	// Specify the yaw rate (multiplier for rudder/steering the ship when steering left/right)
	public float yawRate = 30.0f;
	// Specify the pitch rate (multiplier for pitch when steering up/down)
	public float pitchRate = 100.0f;
	// Weapon mount points on ship (this is where lasers will be fired from)
	public Vector3[] weaponMountPoints;	
	// Laser shot prefab
	public Transform laserShotPrefab;
	// Laser shot sound effect
	public AudioClip soundEffectFire;
	
	// Private variables
	private Rigidbody _cacheRigidbody;

    public bool fly;
    public float startTime;
    public float delay;
    public bool rotationing;
    public int rageH = 20;
    public int rageV = 20;
    public int delayMin = 4;
    public int delayMax = 10;

	void Start () {		
		// Ensure that the thrusters in the array have been linked properly
		foreach (Thruster _thruster in thrusters) {
			if (_thruster == null) {
				Debug.LogError("Thruster array not properly configured. Attach thrusters to the game object and link them to the Thrusters array.");
			}			
		}
		
		// Cache reference to rigidbody to improve performance
		_cacheRigidbody = rigidbody;
		if (_cacheRigidbody == null) {
			Debug.LogError("Spaceship has no rigidbody - the thruster scripts will fail. Add rigidbody component to the spaceship.");
		}

        startTime = Time.time;
        GetRandomDelay();
	}
	
	void Update () {
		// Start all thrusters when pressing Fire 1
        if (fly)
        {		
			foreach (Thruster _thruster in thrusters) {
				_thruster.StartThruster();
			}
            Debug.Log("Delay " + delay);
          
            
		}
		// Stop all thrusters when releasing Fire 1
        if (!fly)
        {		
			foreach (Thruster _thruster in thrusters) {
				_thruster.StopThruster();
			}
		}
		
		if (Input.GetButtonDown("Fire2")) {
			// Itereate through each weapon mount point Vector3 in array
			foreach (Vector3 _wmp in weaponMountPoints) {
				// Calculate where the position is in world space for the mount point
				Vector3 _pos = transform.position + transform.right * _wmp.x + transform.up * _wmp.y + transform.forward * _wmp.z;
				// Instantiate the laser prefab at position with the spaceships rotation
				Transform _laserShot = (Transform) Instantiate(laserShotPrefab, _pos, transform.rotation);
				// Specify which transform it was that fired this round so we can ignore it for collision/hit
				_laserShot.GetComponent<LaserShot>().firedBy = transform;
				
			}
			// Play sound effect when firing
			if (soundEffectFire != null) {
				audio.PlayOneShot(soundEffectFire);
			}
		}

        if (rotationing == false)
        {
            float rH = -RandomHRotationH();
            float rV = RandomVRotationV();
            _cacheRigidbody.AddRelativeTorque(new Vector3(0, 0, -rH * rollRate * _cacheRigidbody.mass));
            _cacheRigidbody.AddRelativeTorque(new Vector3(0, rH * yawRate * _cacheRigidbody.mass, 0));
            _cacheRigidbody.AddRelativeTorque(new Vector3(rV * pitchRate * _cacheRigidbody.mass, 0, 0));
            rotationing = true;
        }
        else
        {
            if (Time.time - startTime > delay)
            {
                _cacheRigidbody.AddRelativeTorque(new Vector3(0, 0, -0 * rollRate * _cacheRigidbody.mass));
                _cacheRigidbody.AddRelativeTorque(new Vector3(0, 0 * yawRate * _cacheRigidbody.mass, 0));
                _cacheRigidbody.AddRelativeTorque(new Vector3(0 * pitchRate * _cacheRigidbody.mass, 0, 0));
                GetRandomDelay();
                rotationing = false;
                startTime = Time.time;
            }
         
        }
      

	}

	void FixedUpdate () {
		
	}

    void RandomFlying()
    {

    }

    float RandomHRotationH()
    {
        System.Random randomH = new System.Random();
        float hvalue = (float)randomH.Next(-rageH, rageV);
        return hvalue;
    }

    float RandomVRotationV()
    {
        System.Random randomV = new System.Random();
        float Vvalue = (float)randomV.Next(-rageH, rageV);
        return Vvalue;
    }

    void GetRandomDelay()
    {
        System.Random timeV = new System.Random();
        delay = timeV.Next(delayMin, delayMax);
    }
}
