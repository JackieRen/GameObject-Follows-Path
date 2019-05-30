using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEngine : MonoBehaviour {
    public Transform cube;
    public Transform path;
    public float maxSteerAngle = 30f;
    public float speed = 0.1f;

    private List<Transform> nodes;
    private int currectNode = 0;

	void Start () {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++) {
            if (pathTransforms[i] != path.transform) {
                nodes.Add(pathTransforms[i]);
            }
        }
    }
	
	void Update () {
        ApplySteer();
        Move();
        CheckWayPointDistance();
    }

    private void ApplySteer()
    {
        if (nodes.Count > 0) {
            Vector3 relativeVector = transform.InverseTransformPoint(nodes[currectNode].position);
            float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
            cube.Rotate(new Vector3(0f, newSteer, 0f));
        }
    }

    private void Move()
    {
        cube.position += transform.forward * speed;
    }

    private void CheckWayPointDistance()
    {
        if (nodes.Count > 0) {
            float distance = Vector3.Distance(cube.position, nodes[currectNode].position);
            if (distance < 1f) {
                if (currectNode == nodes.Count - 1) {
                    currectNode = 0;
                } else {
                    currectNode++; 
                }
            }
        }
    }


}
