using UnityEngine;
using UnityEngine.AI;
using System.IO;


public class betterSavePosition : MonoBehaviour
{
    public float samplingRate = 1f; // sample rate in Hz
    private Transform _AgentmyAgent;
    private void Awake()
    {
        _AgentmyAgent = GetComponent <Transform>();
    }

    private void Update()
    {
        var fileName = _AgentmyAgent.ToString() + "gameobject.txt";
        var t = Time.fixedTime;
        var x = _AgentmyAgent.transform.position.x;
        var y = _AgentmyAgent.transform.position.y;
        var z = _AgentmyAgent.transform.position.z;
        TextWriter tsw = new StreamWriter(fileName, true);
        tsw.WriteLine("{0},{1},{2},{3}", t, x, y, z, true);
        tsw.Close();
    }
}