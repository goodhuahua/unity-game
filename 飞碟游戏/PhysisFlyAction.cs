using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysisFlyAction : SSAction
{//实现物体的物理学飞行，增加一个水平初速度即可
    float speed;//水平速度
    Vector3 direction;//飞行方向
    public static PhysisFlyAction GetSSAction(Vector3 direction,float speed){
		PhysisFlyAction action = ScriptableObject.CreateInstance<PhysisFlyAction> ();
		action.direction=direction;
		action.speed=speed;
		return action;
	}
    // Start is called before the first frame update
    public override void Start()
    {
        //gameobject.GetComponent<Rigidbody>().isKinematic=false;
        //增加一个水平初速度
        //gameobject.GetComponent<Rigidbody>().UseGravity = true;
        gameobject.GetComponent<Rigidbody>().velocity=speed*direction;
    }

    // Update is called once per frame
    public override void Update()
    {
        //time+=Time.deltaTime;
        //transform.Translate(Vector3.down*gravity*time*Time.deltaTime);
        if (this.transform.position.y < -10) {//如果飞碟到达底部，则动作结束，回调
			//waiting for destroy
			this.enable=false;
			this.destory = true;  
			this.callback.SSActionEvent (this);
		}
    }
    // public override void Update() { }
    // public override void FixedUpdate() {
    //     if (this.transform.position.y < -10) {//如果飞碟到达底部，则动作结束，回调
	// 		//waiting for destroy
	// 		this.enable=false;
	// 		this.destory = true;  
	// 		this.callback.SSActionEvent (this);
    //     }
    // }
}
