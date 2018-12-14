using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public Vector3 posA;
    public Vector3 posB;
    public Vector3 nexpos;

    [SerializeField]
    float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;


    void Start () {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nexpos = posB;
	}
	
	
	void Update () {
        Move();	
	}


    private void Move()
    {

        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition
            , nexpos, speed * Time.deltaTime);

        if (Vector3.Distance(childTransform.localPosition,nexpos) <= 0.1)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        nexpos = nexpos != posA ? posA : posB;
    }

   



}
