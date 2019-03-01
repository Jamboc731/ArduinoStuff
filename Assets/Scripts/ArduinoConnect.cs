using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class ArduinoConnect : MonoBehaviour {

    public GameObject playerOne;
    public GameObject playerTwo;
    public bool playing = true;
    public int commPort = 0;

    private SerialPort serial;

    private void Start()
    {
        serial = new SerialPort("\\\\.\\COM" + commPort, 9600);
        serial.ReadTimeout = 50;
        serial.Open();
    }

    private void Update()
    {
        WriteToArduino("p");
        string values = ReadFromArduino();

        if(values != null)
        {
            string[] splitVals = values.Split('-');

            if(splitVals.Length == 2)
            {
                PositionPlayers(splitVals);
            }
        }
    }

    public void WriteToArduino(string msg)
    {
        serial.WriteLine(msg);
        serial.BaseStream.Flush();
    }

    string ReadFromArduino()
    {
        serial.ReadTimeout = 50;
        try
        {
            return serial.ReadLine();
        }
        catch(TimeoutException e)
        {
            return null;
        }
    }

    private void OnDestroy()
    {
        WriteToArduino("r");
        StopAllCoroutines();
        serial.Close();
    }

    void PositionPlayers(string[] vals)
    {

        if(playerOne != null)
        {

            Vector3 newPosOne = new Vector3(playerOne.transform.position.x, int.Parse(vals[0]) / 102.3f, playerOne.transform.position.z);
            Vector3 newPosTwo = new Vector3(playerTwo.transform.position.x, int.Parse(vals[1]) / 102.3f, playerTwo.transform.position.z);

            playerOne.transform.position = newPosOne;
            playerTwo.transform.position = newPosTwo;

        }
        

    }

}
