using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour
{
    public GameObject disk;
    //public DiskData data;
    public Disk(string name){//四种飞碟
        if(name == "disk1"){
                disk = GameObject.Instantiate(Resources.Load<GameObject>("disk1"), Vector3.zero, Quaternion.identity) as GameObject;
                disk.AddComponent<DiskData>();
                //data=disk.GetComponent<DiskData>();
                disk.GetComponent<DiskData>().points=1;
                disk.GetComponent<DiskData>().direction=new Vector3(UnityEngine.Random.Range(-1f, 1f) > 0 ? 2 : -2, 1, 0);
                disk.GetComponent<DiskData>().speed=1.0f;
            }
            else if(name == "disk2"){
                disk = GameObject.Instantiate(Resources.Load<GameObject>("disk2"), Vector3.zero, Quaternion.identity) as GameObject;
                disk.AddComponent<DiskData>();
                //data=disk.GetComponent<DiskData>();
                disk.GetComponent<DiskData>().points=2;
                disk.GetComponent<DiskData>().direction=new Vector3(UnityEngine.Random.Range(-1f, 1f) > 0 ? 2 : -2, 1, 0);
                disk.GetComponent<DiskData>().speed=2.0f;
            }
            else if(name == "disk3"){
                disk = GameObject.Instantiate(Resources.Load<GameObject>("disk3"), Vector3.zero, Quaternion.identity) as GameObject;
                disk.AddComponent<DiskData>();
                //data=disk.GetComponent<DiskData>();
                disk.GetComponent<DiskData>().points=3;
                disk.GetComponent<DiskData>().direction=new Vector3(UnityEngine.Random.Range(-1f, 1f) > 0 ? 2 : -2, 1, 0);
                disk.GetComponent<DiskData>().speed=3.0f;
            }
            else if(name == "disk4"){
                disk = GameObject.Instantiate(Resources.Load<GameObject>("disk4"), Vector3.zero, Quaternion.identity) as GameObject;
                disk.AddComponent<DiskData>();
                disk.GetComponent<DiskData>().points=4;
                disk.GetComponent<DiskData>().direction=new Vector3(UnityEngine.Random.Range(-1f, 1f) > 0 ? 2 : -2, 1, 0);
                disk.GetComponent<DiskData>().speed=4.0f;
            }
            //return disk;
        }
    public GameObject getGameObject(){return disk;}
}
