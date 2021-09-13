using UnityEngine;
using UnityEngine.AI;
using System;
using System.IO;

public class Beast : MonoBehaviour
{
    [SerializeField] private Transform[] _Path1;
    //[SerializeField] private Transform[] _Path2;
    private Transform[] _destinations;
    private NavMeshAgent _navMeshAgent;
    private int _index;
    bool colour_toggle;
    //private StateMachine _stateMachine;
    //public static List<float> nums = new List<float>();


    private void Awake()
     {
         _navMeshAgent = GetComponent<NavMeshAgent>();
        _destinations = _Path1;
        //var Exec_Path1 = new Execute_Path(this, _Path1) // instance of a different Object-script.
        //var Exec_Path2 = new Execute_Path(this, _Path2) // instance of a different Object-script.
        //_stateMachine = new StateMachine();
        //_stateMachine.SetState(Exec_Path1); // path 1 until collision.
        //_stateMachine.AddTransition(Exec_Path1, Exec_Path2, botIsHit()); //OnTriggerEnter as a collision??

    }
    
     private void Update()
     {

        //if (colour_toggle == true)
            //gameObject.GetComponent<Renderer>().material.color = Color.blue;
            //_destinations = _Path1;

        //if (colour_toggle == false)
            //gameObject.GetComponent<Renderer>().material.color = Color.green;
            //_destinations = _Path2;

        // MOVE AUTONOMOUSLY
        if (_navMeshAgent.remainingDistance < 1f)
         {
             var nextDestination = GetNextDestination();
             _navMeshAgent.SetDestination(nextDestination);
         }
        // RECORD POSITION
        //Debug.Log(_navMeshAgent.transform.position);

        // POSITION LOG
        //Debug.Log(_destinations[_index].position);

        var fileName = "gameobject.txt";
        var t = Time.fixedTime;
        var x = _navMeshAgent.transform.position.x;
        var y = _navMeshAgent.transform.position.y;
        var z = _navMeshAgent.transform.position.z;
        TextWriter tsw = new StreamWriter(fileName, true);
        tsw.WriteLine("{0},{1},{2},{3}", t, x, y, z, true);
        tsw.Close();
        // REACT ON COLLISION

     }

    // When 'TRAVERSAL' Collision 
    private void OnTriggerEnter(Collider other)
    {
        var fileName = "enter_contact.txt";
        var t = Time.fixedTime;
        var x = _navMeshAgent.transform.position.x;
        var y = _navMeshAgent.transform.position.y;
        var z = _navMeshAgent.transform.position.z;
        TextWriter tsw = new StreamWriter(fileName, true);
        tsw.WriteLine("{0},{1},{2},{3}", t, x, y, z, true);
        tsw.Close();
    }

    private void OnTriggerExit(Collider other)
    {
        colour_toggle = !colour_toggle;
    }
    // When 'HARD' Collision
    //void OnCollisionEnter()
    //{
    //    colour_toggle = !colour_toggle;
    //}

    private Vector3 GetNextDestination()
     {
         _index++;
         if (_index >= _destinations.Length)
             _index = 0;
    
         return _destinations[_index].position;
     }
}