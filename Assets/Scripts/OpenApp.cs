using UnityEngine;

public class OpenApp : MonoBehaviour
{
    public Transform appBar;

	private AppManager appManager;

	private void Start()
	{
		
	}

	public void OpenAppF(GameObject app)
    {
		if (appManager == null)
			appManager = GameObject.Find("Taskbar").GetComponent<AppManager>();

		GameObject obj = Instantiate(app, appBar.position, Quaternion.identity, appBar);
		obj.transform.Find("MainPanel").Find("Upbar").GetComponent<DefaultAppScript>().OnInstantiate();
		appManager.AddToTaskbar(obj.name);
	}
}
