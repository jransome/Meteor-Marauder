using UnityEngine;

public class CameraTopDownFollow : MonoBehaviour {

    public Transform Target;
    public float CameraDistance = 10f;

    void Start()
    {
        GetComponentInChildren<Camera>().orthographicSize = CameraDistance;
    }

    void Update ()
    {
        if (Target != null)
        {
            FollowTarget();
        }	
	}

    void FollowTarget()
    {
        transform.position = Target.position;
    }
}
