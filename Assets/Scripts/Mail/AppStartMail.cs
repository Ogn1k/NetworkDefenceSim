using UnityEngine;

public class AppStartMail : AppStart
{
	public override void OnOpen()
	{
		//print("opened!");
		gameObject.GetComponent<MailSaveController>().UpdateObjs();
		notificationManager.RegisterMailClient(gameObject.GetComponent<MailMessageHandler>());
	}
}
