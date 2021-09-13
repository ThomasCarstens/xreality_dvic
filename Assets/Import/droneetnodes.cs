using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneetnodes : MonoBehaviour
{
    public Transform path;
    public List<Transform> nodes;
    public int currentNode = 0;
    public float movementSpeed = 10.5f;
    public float rotationSpeed = 9.0f;
    Rigidbody ourDrone;

    void Awake()
    {
        ourDrone = GetComponent<Rigidbody>();
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()

    {
        //MovementUpandDown();
        Rotation();
        CheckWaypointDistance();
        print("afterwaydist");
        ourDrone.AddRelativeForce(Vector3.up * upForce);
    }

    public float upForce;
    void MovementUpandDown()
    {
        upForce = 98.1f;
    }
    private void Rotation()
    {
  
        Vector3 relativeVector = nodes[currentNode].position;
        relativeVector.y = transform.position.y;
        Vector3 angle = relativeVector - transform.position;

        Quaternion directionDrone = Quaternion.LookRotation(angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, directionDrone, rotationSpeed * Time.deltaTime);

        //print(Quaternion.LookRotation(angle));
        if (Quaternion.Angle(transform.rotation, directionDrone) <= 1)
        {
            transform.Translate(new Vector3(0, 0, movementSpeed * Time.deltaTime));
        }
        
    }
    private void CheckWaypointDistance()
    {
        print("enterredway");
        //print(Vector3.Distance(transform.position, nodes[currentNode].position));
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 3.6f)
        {
            print("firstif");
            if (currentNode == nodes.Count - 1)
            {
                currentNode = 0;
                print("zeronode");
            }
            else
            {
                currentNode++;
                print("nextnode");
            }
        }
    }
}
