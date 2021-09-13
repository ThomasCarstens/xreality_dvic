using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class log_recorder : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform _AgentmyAgent;
    DateTime localDate = DateTime.Now;
    long Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

    void Start()
    {
        _AgentmyAgent = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var fileName = "Logs/LogPosition/" + Timestamp.ToString() + _AgentmyAgent.ToString() + "gameobject.txt";
        var t = Time.fixedTime;
        var x = _AgentmyAgent.transform.position.x;
        var y = _AgentmyAgent.transform.position.y;
        var z = _AgentmyAgent.transform.position.z;
        TextWriter tsw = new StreamWriter(fileName, true);
        tsw.WriteLine("{0},{1},{2},{3}", t, x, y, z, true);
        tsw.Close();
    }
}
