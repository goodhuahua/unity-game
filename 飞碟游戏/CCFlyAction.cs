using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCFlyAction : SSAction
{
	public Vector3 direction;
	public float speed;
	float gravity;
	float time;
    //public FirstController sceneController;

	public static CCFlyAction GetSSAction(Vector3 direction,float speed){
		CCFlyAction action = ScriptableObject.CreateInstance<CCFlyAction> ();
		action.direction=direction;
		action.speed=speed;
		action.gravity=9.8f;
		action.time=0;
		return action;
	}

	public override void Update ()
	{
		//获取上一帧渲染所消耗的时间
		time+=Time.deltaTime;
		//使物体沿着重力方向下落
		transform.Translate(Vector3.down*gravity*time*Time.deltaTime);
		//在每一帧更新物体的位置,使运动与帧率无关
		transform.Translate(direction*speed*Time.deltaTime);
		// this.transform.position = Vector3.MoveTowards (this.transform.position, target, speed * Time.deltaTime);
		if (this.transform.position.y < -10) {//如果飞碟到达底部，则动作结束，回调
			//waiting for destroy
			this.enable=false;
			this.destory = true;  
			this.callback.SSActionEvent (this);
		}
		
	}
	
	public override void Start () {
		//将对象设为刚体
		gameobject.GetComponent<Rigidbody>().isKinematic=true;
	}
}

