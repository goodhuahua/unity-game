﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSActionManager : MonoBehaviour {

	private Dictionary <int, SSAction> actions = new Dictionary <int, SSAction> ();
	private List <SSAction> waitingAdd = new List<SSAction> (); 
	private List<int> waitingDelete = new List<int> ();

	// Update is called once per frame
	protected void Update () {
		foreach (SSAction ac in waitingAdd) actions [ac.GetInstanceID ()] = ac;
		waitingAdd.Clear ();

		foreach (KeyValuePair <int, SSAction> kv in actions) {
			SSAction ac = kv.Value;
			if (ac.destory) { 
				waitingDelete.Add(ac.GetInstanceID()); // release action
			} else if (ac.enable) { 
				ac.Update (); // update action
				//ac.FixedUpdate(); // 物理引擎
			}
		}

		foreach (int key in waitingDelete) {
			SSAction ac = actions[key]; 
			actions.Remove(key); 
			Object.Destroy(ac);
		}
		waitingDelete.Clear ();
	}

	public void RunAction(GameObject gameobject, SSAction action, ISSActionCallback manager) {
		action.gameobject = gameobject;
		action.transform = gameobject.transform;
		action.callback = manager;
		waitingAdd.Add (action);
		action.Start ();
	}


	// Use this for initialization
	protected void Start () {
	}
}
