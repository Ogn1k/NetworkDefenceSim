using UnityEngine;

public class OpenApp : MonoBehaviour
{
    public Transform appBar;

	private AppManager appManager;

	private NotificationManager notificationManager;

	private void Start()
	{
		
	}

	public void OpenAppF(GameObject app)
    {
		if (appManager == null)
			appManager = GameObject.Find("Taskbar").GetComponent<AppManager>();

		if (notificationManager == null)
			notificationManager = GameObject.Find("Notifications").GetComponent<NotificationManager>();

		GameObject obj = Instantiate(app, appBar.position, Quaternion.identity, appBar);
		obj.transform.Find("MainPanel").Find("Upbar").GetComponent<DefaultAppScript>().OnInstantiate();
		appManager.AddToTaskbar(obj.name);

		if(obj.GetComponent<AppStart>())
		{
			AppStart appStarter = obj.GetComponent<AppStart>();
			appStarter.SetNotificationManager(notificationManager);
			appStarter.OnOpen();
			
		}


	}
}
