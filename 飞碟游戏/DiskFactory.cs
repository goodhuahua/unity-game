using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFactory : MonoBehaviour
{
    // Start is called before the first frame update
    List<DiskData> used;
    List<DiskData> free;
    public void Start(){
        used = new List<DiskData>();
        free = new List<DiskData>();
    }
    public GameObject GetDisk(){
        Debug.Log("get...\n");
        Disk disk=null; 
        GameObject d;
        int rand=Random.Range(0,99);//生成一个随机数
        if(free.Count>0){//若还有空闲的飞碟，就将其加入
            Debug.Log("free...\n");
            d=free[0].gameObject;
            //disk.getGameObject().SetActive(true);
            free.Remove(free[0]);
        }
        else{
            Debug.Log("new...\n");
            if(rand%4==0){
                disk=new Disk("disk1");
            }
            else if(rand%4==1){
                disk=new Disk("disk2");
            }
            else if(rand%4==2){
                disk=new Disk("disk3");
            }
            else{
                disk=new Disk("disk4");
            }
            d=disk.getGameObject();
        }
        used.Add(d.GetComponent<DiskData>());
        return d;
    }
    public void FreeDisk(GameObject disk){
        for(int i=0;i<used.Count;i++){
            if(disk.GetInstanceID() == used[i].gameObject.GetInstanceID()){
                //used[i].getGameObject().SetActive(false);
                disk.SetActive(false);
                used.Remove(used[i]);
                free.Add(used[i]);
                break;
            }
        } 
    }
}
