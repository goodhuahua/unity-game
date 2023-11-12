using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecorder
{
    static int points=0;//记录游戏当前比分
    public ScoreRecorder(){
        points=0;
    }
    public void Record(DiskData disk){
        //Debug.Log("1\n");
        points +=disk.points;
    }
    public int GetPoints(){
        return points;
    }
    public void Reset(){
        points=0;
    }
}