using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager : SSActionManager, ISSActionCallback, IActionManager{
	
	private FirstController sceneController;
	public CCFlyAction flyAction;

	protected new void Start() {
		sceneController = (FirstController)SSDirector.getInstance ().currentSceneController;
		sceneController.actionManager=this;
	}

	// Update is called once per frame
	public void Fly(GameObject disk,float speed,Vector3 direction){//实现飞行动作
		flyAction=CCFlyAction.GetSSAction(direction,speed);
		RunAction(disk,flyAction,this);
	}
		
	#region ISSActionCallback implementation
	public void SSActionEvent (SSAction source, SSActionEventType events = SSActionEventType.Competeted, int intParam = 0, string strParam = null, Object objectParam = null)
	{
		//飞碟结束飞行后回收飞碟
		sceneController.FreeDisk(source.gameobject);
	}
	#endregion
}

