
using UnityEngine;
using System.Collections;

public class TargetCameraFollow : MonoBehaviour {
	
	// Using UpdateMode you can select when the camera should be updated
	// Depending on your design camera jitter may occur which may be reduced if you change
	// the update mode. In the included demo the best result is achieved when camera is
	// updated in the FixedUpdate() function.
	
	public enum UpdateMode { FIXED_UPDATE, UPDATE, LATE_UPDATE }
	public UpdateMode updateMode = UpdateMode.FIXED_UPDATE;
	
	// Select the chase mode (chase behind target or moving spectator)
	// CHASE = smooth chase behind target at distance and height
	// SPECTATOR = smooth look at target from a chasing spectator position
	public enum FollowMode { CHASE, SPECTATOR, FOLLOWER }	
	public FollowMode followMode = FollowMode.SPECTATOR;
	
	// Target to follow
	public Transform target;
		
	// Distance to follow from (this is the minimum distance, 
	// depending on damping the distance will increase at speed)
	public float distance = 60.0f;	
	// Height for chase mode camera
	public float chaseHeight = 15.0f;
	
	// Follow (movement) damping. Lower value = smoother
	public float followDamping = 0.3f;
	// Look at (rotational) damping. Lower value = smoother
	public float lookAtDamping = 4.0f;	
	// Optional hotkey for freezing camera movement
	public KeyCode freezeKey = KeyCode.None;
		
	private Transform _cacheTransform;
	
	void Start () {
		// Cache reference to transform to increase performance
		_cacheTransform = transform;
	}
	
	void FixedUpdate () {
		if (updateMode == UpdateMode.FIXED_UPDATE) DoCamera();
	}	
	void Update () {
		if (updateMode == UpdateMode.UPDATE) DoCamera();
	}
	void LateUpdate () {
		if (updateMode == UpdateMode.LATE_UPDATE) DoCamera();
	}
	
	void DoCamera () {
		// Return if no target is set
		if (target == null) return;
		
		Quaternion _lookAt;
		
		switch (followMode) {
		case FollowMode.SPECTATOR:
			// Smooth lookat interpolation
			_lookAt = Quaternion.LookRotation(target.position - _cacheTransform.position);
			_cacheTransform.rotation = Quaternion.Lerp(_cacheTransform.rotation, _lookAt, Time.deltaTime * lookAtDamping);
			// Smooth follow interpolation
			if (!Input.GetKey(freezeKey)) {
				if (Vector3.Distance(_cacheTransform.position, target.position) > distance) {					
					_cacheTransform.position = Vector3.Lerp(_cacheTransform.position, target.position, Time.deltaTime * followDamping);
				}
			}
			break;			
		case FollowMode.CHASE:			
			if (!Input.GetKey(freezeKey)) {	
				// Smooth lookat interpolation
				_lookAt = target.rotation;
				_cacheTransform.rotation = Quaternion.Lerp(_cacheTransform.rotation, _lookAt, Time.deltaTime * lookAtDamping);						
				// Smooth follow interpolation
				_cacheTransform.position = Vector3.Lerp(_cacheTransform.position, target.position - target.forward * distance + target.up * chaseHeight, Time.deltaTime * followDamping * 10) ;
			}
			break;
        case FollowMode.FOLLOWER:
            if (!Input.GetKey(freezeKey))
            {
                _lookAt = target.rotation;
            }

            break;

		}			
		
	}	
}
