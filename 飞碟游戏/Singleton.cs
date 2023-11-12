using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{//运用模板，可以为每个 MonoBehaviour子类 创建一个对象的实例。
    protected static T instance;

	public static T Instance {  //在任意位置使用代码 Singleton<YourMonoType>.Instance 获得该对象。
		get {  
			if (instance == null) { 
				instance = (T)FindObjectOfType (typeof(T));  
				if (instance == null) {  
					Debug.LogError ("An instance of " + typeof(T) +
					" is needed in the scene, but there is none.");  
				}  
			}  
			return instance;  
		}  
	}
}
