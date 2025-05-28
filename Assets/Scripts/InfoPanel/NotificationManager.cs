using Aspose.Email;
using MimeKit;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
	public GameObject notificationPrefab;
	public GameObject infoPanelContent;

	private MailMessageHandler currentMailClient;
	public MailBackground currentMailBackground;

	private List<string> notifications = new List<string>();

	public void RegisterMailClient(MailMessageHandler mailClient)
	{
		// Отписываемся от предыдущего клиента, если он был
		if (currentMailClient != null)
			currentMailClient.OnMailReceived -= ShowNotification;

		currentMailClient = mailClient;

		if (currentMailClient != null)
			currentMailClient.OnMailReceived += ShowNotification;
	}

	public void RegisterMailBackground(MailBackground mailBackground)
	{
		// Отписываемся от предыдущего клиента, если он был
		if (currentMailBackground != null)
			currentMailBackground.OnMailReceived -= ShowNotification;

		currentMailBackground = mailBackground;

		if (currentMailBackground != null)
			currentMailBackground.OnMailReceived += ShowNotification;
	}

	private void ShowNotification(MimeMessage message)
	{
		//Debug.Log("Уведомление: " + message.Subject);
		// Здесь ваша логика отображения уведомления
		notifications.Add(message.Subject);
		InstantiateNotificationWithAnimation(message.Subject);
	}

	private void InstantiateNotificationWithAnimation(string text)
	{
		GameObject notif = Instantiate(notificationPrefab, transform);
		notif.transform.Find("Text").GetComponent<TMP_Text>().text = text.Truncate(10);
		notif.GetComponent<Animator>().SetTrigger("anim");

		
	}


}
