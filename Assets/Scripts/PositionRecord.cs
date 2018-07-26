using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.IO;

public class PositionRecord : MonoBehaviour
{
    public GameObject Player;
    Transform trans;
    public InputField recfilename;
    public Button StartStop;
    public Button CreateFile;
    private bool recording;
    private DateTime recordtime;
    //private string filename;
    private StreamWriter writer;
	// Use this for initialization
	void Start ()
    {
        //Player = GameObject.FindGameObjectWithTag("Player");
        //Player = this.gameObject;
        trans = Player.transform;
        recfilename.text = "file01";
        recording = false;
        Button b = StartStop.GetComponent<Button>();
        Button c = CreateFile.GetComponent<Button>();
        b.onClick.AddListener(ToggleRecord);
        c.onClick.AddListener(CreateNewFile);
        //if (File.Exists(recfilename.text))
        //{
        //    Debug.Log(recfilename.text + " Exisits creating new file:");
        //    writer = File.CreateText(recfilename.text + "_new.txt");
        //}
        //else
        //{
        //    writer = File.CreateText(recfilename.text);
        //}
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(trans.position.x);
        recordtime = DateTime.Now;
        string data = trans.position.x.ToString() + '\t' + trans.position.z.ToString() + '\t' + trans.position.y.ToString() + '\t' + 
            trans.rotation.eulerAngles.x.ToString() + '\t' + trans.rotation.eulerAngles.y.ToString() + '\t' + trans.rotation.eulerAngles.z.ToString() + '\t' +
            recordtime.ToString("HH") + '\t' + recordtime.ToString("mm") + '\t' + recordtime.ToString("ss") + '\t' + recordtime.ToString("ffff");
        //Debug.Log(position);
        Debug.Log(recfilename.text);
        Debug.Log("recording:" + recording.ToString());
        if (recording)
        {
            writer.WriteLine(data);
        }
        //else
        //{
        //    writer.Close();
        //}
        //writer.WriteLine(position);
    }

    void ToggleRecord()
    {
        recording = !recording;
    }

    void CreateNewFile()
    {
        if (!recording)
        {
            if (File.Exists(recfilename.text))
            {
                Debug.Log(recfilename.text + " Exisits creating new file:");
                writer = File.CreateText(recfilename.text + "_new.txt");
            }
            else
            {
                writer = File.CreateText(recfilename.text + ".txt");
            }
        }
    }

}
