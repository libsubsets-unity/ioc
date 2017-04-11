using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using libunity.ioc;

public class App : MonoBehaviour {
	// Use this for initialization
	void Awake () {
    Logger logger = new GameObject("logger").AddComponent<Logger>();
    Service_Dependency.register(logger);

    // 일반 C# 클래스는 삭제 여부를 확인할 수 없다. null 검사가 안된다.
    // 하지만 다시 유니티 컴포넌트의 변수로 가져오면 null 체크가 가능하다.
    // 그러므로 dependencies 클래스가 꼭 MonoBehaviour를 상속받을 필요는 없다.
    //Destroy(logger.gameObject);
    logger.debug("App Start");
	}
	
	// Update is called once per frame
	void Update () {
	}
}
