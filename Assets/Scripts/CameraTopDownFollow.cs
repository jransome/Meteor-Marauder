using UnityEngine;

public class CameraTopDownFollow : MonoBehaviour {

    public Transform Target;
    public float CameraDistance = 10f;

    void Update ()
    {
        if (Target != null)
        {
            FollowTarget();
        }	
	}

    void FollowTarget()
    {
        Vector3 targetPosition = Target.position;
        targetPosition.z -= CameraDistance;
        transform.position = targetPosition;
    }
}
