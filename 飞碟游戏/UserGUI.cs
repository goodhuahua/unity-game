using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    IUserAction action;
    public string gameMessage ;
    int points;

    void Start()
    {
        Debug.Log("UserGUI...\n");
        points=0;
        gameMessage=" ";
        action=SSDirector.getInstance().currentSceneController as IUserAction;
    }

    public void SetMessage(string gameMessage)
    {
        this.gameMessage=gameMessage;
    }
    public void SetPoints(int points)
    {
        this.points=points;
    }
    private void OnGUI()
    {
        //小字体
        GUIStyle fontStyle = new GUIStyle();
        fontStyle.fontSize = 30;
        fontStyle.normal.textColor = Color.white;
        //大字体
        GUIStyle bigStyle = new GUIStyle();
        bigStyle.fontSize = 50;
        bigStyle.normal.textColor = Color.white;
        
        if(action.Check()){
            SetMessage("GameOver!");
        }
        else{
            SetMessage("");
        }
        SetPoints(action.GetPoints());
        if (GUI.Button(new Rect(20, 50, 100, 40), "Restart"))
        {
            SetMessage("");
            //清零得分
            SetPoints(0);
            action.Restart();
        }
        if (GUI.Button(new Rect(20, 100, 100, 40), "Normal Mode"))
        {
            action.SetMode(false);
        }
        if (GUI.Button(new Rect(20, 150, 100, 40), "Infinite Mode"))
        {
            action.SetMode(true);
        }
        if (GUI.Button(new Rect(20, 200, 100, 40), "Kinematics"))
        {
            action.setFlyMode(false);
        }
        if (GUI.Button(new Rect(20, 250, 100, 40), "Physis"))
        {
            action.setFlyMode(true);
        }
        //返回鼠标点击的位置
        if(Input.GetButtonDown("Fire1"))//获取鼠标点击
        {
            Debug.Log ("Fired Pressed");
            action.Hit(Input.mousePosition);
        }
        GUI.Label(new Rect(300,30,50,200),"Hit UFO",bigStyle);
        GUI.Label(new Rect(20,0,100,50),"Points: "+points,fontStyle);
        Debug.Log("points:"+points+"\n");
        Debug.Log("message:"+gameMessage+"\n");
        GUI.Label(new Rect(310, 100, 50, 200), gameMessage, fontStyle);
    }
}
