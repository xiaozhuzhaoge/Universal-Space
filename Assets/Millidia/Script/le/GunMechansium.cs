using UnityEngine;
using System.Collections;

public class GunMechansium : MonoBehaviour {

    public Transform target;
    public float RangeAngle = 50;
    public float distance = 2;
    public Transform Tower;
    public float drawDistance = 100000;
    public Color m_Color = Color.green; // 线框颜色
    public Transform Bullet;
    public float FireTime;
    public float TimeDelay = 3;
    public bool rageFlag = false;
    public bool distanceFlag = false;
    public Transform bulletShotPoint;
    public Transform FireEffect;
    public Renderer render;
	// Use this for initialization
	void Start () {
        FireTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (WarningArea())
        {
            Fire();
            RotationedByTarget();
            Tower.gameObject.SetActive(true);
        }
        else
            Tower.gameObject.SetActive(false);
        
	}

    void RotationedByTarget()
    {
        Vector3 march = target.transform.position - Tower.transform.position;
        march.y = 0;
        var newRotation = Quaternion.LookRotation(march);
        Tower.transform.rotation = Quaternion.Slerp(Tower.transform.rotation, newRotation, Time.deltaTime * 8);
    }

    public float getAngle()
    {

        return Vector3.Angle(transform.forward, target.transform.position - transform.position); 
    }

    public float getDistance()
    {
        return Vector3.Distance(transform.position, target.transform.position);
    }

    bool WarningArea()
    {
        if (target == null)
            return false;


        if (distanceFlag && rageFlag)
            return getAngle() <= RangeAngle && getDistance() <= distance;
        else if (distanceFlag)
            return getDistance() <= distance;
        else if (rageFlag)
            return getAngle() <= RangeAngle;
        else
            return false;
    }



    void OnDrawGizmos()
    {
        if (transform == null)
            return;
     
        Vector3 from = transform.position;

        if(rageFlag)
        {
            Gizmos.color = Color.green;
            float RealAngle = RangeAngle + transform.rotation.eulerAngles.y;
            float RealAngleN = RangeAngle - transform.rotation.eulerAngles.y;

            float LRad = Mathf.Deg2Rad * RealAngle;
            float xR = distance * Mathf.Sin(LRad);
            float zR = distance * Mathf.Cos(LRad);
            Vector3 RightTo = from + new Vector3(xR, 0, zR);
            Gizmos.DrawLine(from, RightTo);

            float RRad = Mathf.Deg2Rad * -RealAngleN;
            float xL = distance * Mathf.Sin(RRad);
            float zL = distance * Mathf.Cos(RRad);
            Vector3 LeftTo = from + new Vector3(xL, 0, zL);
            Gizmos.DrawLine(from, LeftTo);

            if(distanceFlag)
            {
                Vector3 begin = LeftTo;
                for (float theta = Mathf.Deg2Rad * -RealAngleN; theta < Mathf.Deg2Rad * RealAngle; theta += 0.001f)
                {
                    float x = distance * Mathf.Sin(theta);
                    float z = distance * Mathf.Cos(theta);
                    Vector3 nextPoint = from + new Vector3(x, 0, z);
                    Gizmos.DrawLine(begin, nextPoint);
                    begin = nextPoint;
                }
            }
          
        }

        if (distanceFlag && !rageFlag)
        {
            Gizmos.color = Color.yellow;
            Vector3 forwardP = from + Vector3.forward * distance;
            //Gizmos.DrawLine(transform.position, forwardP);

            Vector3 begin = forwardP;
            for (float theta = 0; theta < 2 * Mathf.PI; theta += 0.001f)
            {
                float x = distance * Mathf.Sin(theta);
                float z = distance * Mathf.Cos(theta);
                Vector3 nextPoint = from + new Vector3(x, 0, z);
                Gizmos.DrawLine(begin, nextPoint);
                begin = nextPoint;
            }
        }

        //DrawCircle();
    }

    void DrawCircle()
    {
        Vector3 center = render.bounds.center;
        float radius = render.bounds.extents.magnitude;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(center, radius);
    }


    void Fire()
    {
        if (Time.time - FireTime < TimeDelay)
            return;

        FireTime = Time.time;
        GameObject B = (GameObject)Instantiate(Bullet.gameObject, bulletShotPoint.position, Quaternion.identity);
        B.transform.LookAt(target);
        B.SetActive(true);
    
    }
}
