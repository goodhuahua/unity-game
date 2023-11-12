using System;
using UnityEngine;

public interface IUserAction
{
	void setFlyMode(bool isPhysis);//设置飞行模式
    void Hit(Vector3 position);//点击
    void Restart();//重置
    void SetMode(bool isInfinite);//选择模式
    bool Check();
    int GetPoints();
}


