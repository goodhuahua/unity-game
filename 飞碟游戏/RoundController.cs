using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    //FirstController firstController;
    IActionManager actionManager;
    DiskFactory diskFactory;
    ScoreRecorder scoreRecorder;
    //UserGUI userGUI;
    int[] roundDisks;//对应回合的飞碟数
    bool isInfinite;//游戏当前模式
    int round;//游戏当前轮次
    int sendCnt;//当前已发送飞碟
    float sendTime;//发送时间
    public bool isEnd;//游戏是否结束
    // Start is called before the first frame update
    void Start()
    {
        actionManager=Singleton<CCActionManager>.Instance;
        diskFactory=Singleton<DiskFactory>.Instance;
        Debug.Log("diskFactory...\n");
        scoreRecorder=new ScoreRecorder();
        sendCnt=0;
        round=0;
        sendTime=0;
        isInfinite=false;
        isEnd=false;
        roundDisks=new int[]{3,5,8,13,21};
    }

    public void Reset()
    {
        sendCnt=0;
        round=0;
        sendTime=0;
        isEnd=false;
        scoreRecorder.Reset();
        //userGUI.SetMessage("");
    }

    public void Record(DiskData disk){
        scoreRecorder.Record(disk);
    }

    public int GetPoints(){
        return scoreRecorder.GetPoints();
    }

    public void SetMode(bool isInfinite){
        this.isInfinite=isInfinite;
    }

    public void setFlyMode(bool isPhysis){
        actionManager=isPhysis? Singleton<PhysisActionManager>.Instance as IActionManager: Singleton<CCActionManager>.Instance as IActionManager; 
    }

    public void SendDisk(){//发送飞碟
        //从工厂生成一个飞碟
        GameObject disk=diskFactory.GetDisk();
        Debug.Log("getdisk...\n");
        //设置随机位置
        disk.transform.position=new Vector3(-disk.GetComponent<DiskData>().direction.x*7,UnityEngine.Random.Range(3f,8f),0);
        disk.SetActive(true);
        actionManager.Fly(disk,disk.GetComponent<DiskData>().speed,disk.GetComponent<DiskData>().direction);
    }
    // Update is called once per frame
    void Update()
    {
        sendTime+=Time.deltaTime;
        //每隔1s发送一次飞碟
        if(sendTime>1)
        {
            sendTime=0;
            //每次最多发送3个飞碟
            for(int i=0;i<2&&sendCnt<roundDisks[round];i++)
            {
                sendCnt++;
                this.SendDisk();
            }
        }
        //判断是否需要重置轮次
        if(sendCnt>=roundDisks[round]&&round==(roundDisks.Length-1))
        {//最后一轮结束
            if(isInfinite){
                round=0;
                sendCnt=0;
                isEnd=false;
                //userGUI.SetMessage("");
            }
            else{
                //userGUI.SetMessage("Game Over!");
                isEnd=true;
                //round=0;
                //sendCnt=0;
            }
        }
        //更新轮次
        if(sendCnt>=roundDisks[round]&&round<(roundDisks.Length-1))
        {
            sendCnt=0;
            round++;
        }
    }
}
