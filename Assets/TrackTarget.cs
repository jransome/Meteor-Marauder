using UnityEngine;

public class TrackTarget : MonoBehaviour {

    public Transform Target;
    private Engines engines;

    float angle;

    void Start()
    {
        engines = GetComponent<Engines>();
    }

    void FixedUpdate()
    {
        //Vector2 direction = Target.position - transform.position;
        angle = Vector2.SignedAngle(Target.position, transform.position);
        Debug.Log(angle);

    }

}
