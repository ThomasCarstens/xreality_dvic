using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class EventController : MonoBehaviour
{
    private Transform _AgentmyAgent;
    long Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    public string state = "ok";
    //public Collider col;

    void OnTriggerExit(Collider other)
    {
        print(other.tag);
        print("col exit");
        if (other.tag == "cage")
        {
            print("col cage");
            state = "home";
        }
        else if (other.tag == "flying")
        {
            print("end of collision");
            state = "ok";
        }
    }
    void OnTriggerEnter(Collider other)
    {
        print("colenter");
        if (other.tag == "wall")
        {
            print("wall");
            for (int i = 0; i < 100; i++)
            {
                state = "kill";
            }
            state = "ok";
        }
        else if (other.CompareTag("flying"))
        {
            print("flying");
            state = "kill";
        }

        _AgentmyAgent = GetComponent<Transform>();
        var fileName = "Logs/LogCollision/" + Timestamp.ToString() + _AgentmyAgent.ToString() + "_collision.txt";
        var t = Time.fixedTime;
        var x = _AgentmyAgent.transform.position.x;
        var y = _AgentmyAgent.transform.position.y;
        var z = _AgentmyAgent.transform.position.z;
        TextWriter tsw = new StreamWriter(fileName, true);
        tsw.WriteLine("{0},{1},{2},{3}", t, x, y, z, true);
        tsw.Close();
    }
}
