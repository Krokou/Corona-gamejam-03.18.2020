using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

    public GameObject objToFollow;
    public Vector2 targetPos;

    public float distanceFactor;

    private Rigidbody2D thisRBody;
    private Rigidbody2D rBodyOfObj;
    private Vector3 worldTargetPos;
    private Vector2 distanceToTarget;

	// Use this for initialization
	void Start () {

        // Initialize object to follow. Set to parent object if not set in editor.
        if(objToFollow == null) {
            objToFollow = transform.parent.gameObject;
        }
        rBodyOfObj = objToFollow.GetComponent<Rigidbody2D>();
        thisRBody = GetComponent<Rigidbody2D>();
        worldTargetPos = new Vector3(objToFollow.transform.position.x + targetPos.x, objToFollow.transform.position.y + targetPos.y, 0.0f);
        transform.position = worldTargetPos;
	}

    private void FixedUpdate()
    {
        
        // Set the target for the familiar in world coordinates.
        worldTargetPos = new Vector3(objToFollow.transform.position.x + targetPos.x, objToFollow.transform.position.y + targetPos.y, 0.0f);

        // If player/object is moving to the left, place familiar on the right of player/object.
        if (rBodyOfObj.velocity.x < -0.01f)
        {
            if (targetPos.x < 0.0f)
            {
                targetPos = new Vector2(targetPos.x * -1.0f, targetPos.y);
            }
        }

        // If player/object is moving to the right, place familiar on the left of player/object.
        if (rBodyOfObj.velocity.x > 0.01f)
        {
            if (targetPos.x > 0.0f)
            {
                targetPos = new Vector2(targetPos.x * -1.0f, targetPos.y);
            }
        }

        distanceToTarget = worldTargetPos - transform.position;
        distanceToTarget = distanceToTarget.normalized * Mathf.Pow(distanceToTarget.magnitude, distanceFactor);
        
        thisRBody.velocity = distanceToTarget;
    }
}
