using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction {

	DiskFactory diskFactory;
    RoundController roundController;
    //UserGUI userGUI;
    public IActionManager actionManager;
	public int points;
	void Awake () {
		SSDirector director = SSDirector.getInstance ();
		director.setFPS (60);
        points=0;
		director.currentSceneController = this;
        LoadResources ();
    }
	// loading resources for first scence
	public void LoadResources () {
		UnityEngine.Debug.Log("load...\n");
        //获得对象
        diskFactory=Singleton<DiskFactory>.Instance;
        roundController=Singleton<RoundController>.Instance;
        //userGUI=Singleton<UserGUI>.Instance;
	}

	public void Pause ()
	{
		throw new System.NotImplementedException ();
	}

	public void Resume ()
	{
		throw new System.NotImplementedException ();
	}

    public void FreeDisk(GameObject disk){
        diskFactory.FreeDisk(disk);
    }

	#region IUserAction implementation
    public bool Check(){//检查比赛是否结束
        return roundController.isEnd;
    }
	public void Hit(Vector3 position){//光标拾取多个物体
        Camera ca = Camera.main;;
		Ray ray = ca.ScreenPointToRay(position);

		//Return the ray's hits
		// RaycastHit[] hits = Physics.RaycastAll (ray);

		// 	foreach (RaycastHit hit in hits) {
		// 		//print (hit.transform.gameObject.name);
		// 		if (hit.collider.gameObject.GetComponent<DiskData>() != null) { //点击飞碟
		// 			Debug.Log ("hit " + hit.collider.gameObject.name +"!" ); 
        //             //将飞碟移至底端，触发动作回调
        //             //移动位置
        //             hit.collider.gameObject.transform.position=new Vector3(0,-7,0);
        //             //积分
        //             roundController.Record(hit.collider.gameObject.GetComponent<DiskData>());
        //             //更新GUI数据,更新得分
        //             userGUI.SetPoints(roundController.GetPoints());
		// 		}
		// 	}
        //Return the ray's hit
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				print (hit.transform.gameObject.name);
				if (hit.collider.gameObject.GetComponent<DiskData>() != null) { //plane tag
					Debug.Log ("hit " + hit.collider.gameObject.name +"!" ); 
                    //将飞碟移至底端，触发动作回调
                    //移动位置
                    hit.collider.gameObject.transform.position=new Vector3(0,-7,0);
                    //积分
                    roundController.Record(hit.collider.gameObject.GetComponent<DiskData>());
                    //更新GUI数据,更新得分
                    //userGUI.SetPoints(roundController.GetPoints());
                    //更新GUI数据
                    points=roundController.GetPoints();
				}
				//Destroy (hit.transform.gameObject);
			}
        // RaycastHit[] hits;
        // hits = Physics.RaycastAll(ray);

        // for (int i = 0; i < hits.Length; i++)
        // {
        //     RaycastHit hit = hits[i];
        //     if (hit.collider.gameObject.GetComponent<DiskData>() != null)
        //     {
        //         Debug.Log ("hit " + hit.collider.gameObject.name +"!" ); 
        //         //将飞碟移至底端，触发飞行动作的回调
        //         hit.collider.gameObject.transform.position = new Vector3(0, -7, 0);
        //         //积分
        //         roundController.Record(hit.collider.gameObject.GetComponent<DiskData>());
        //         //更新GUI数据
        //         points=roundController.GetPoints();
        //         //userGUI.SetPoints(roundController.GetPoints());
        //     }
        // }
    }
	public int GetPoints(){
        return points;
    }
    public void Restart()//游戏重新开始
    {
        //userGUI.SetMessage(" ");
        //清零得分
        //userGUI.SetPoints(0);
        roundController.Reset();
        points=0;
        
    }

    public void SetMode(bool isInfinite){
        roundController.SetMode(isInfinite);
    }
    
    public void setFlyMode(bool isPhysis){
        roundController.setFlyMode(isPhysis);
    }
    #endregion
    void Update(){

    }
}
