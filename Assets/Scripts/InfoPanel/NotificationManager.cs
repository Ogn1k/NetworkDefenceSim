using Aspose.Email;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
	public GameObject notificationPrefab;
	public GameObject infoPanelContent;

	private MailMessageHandler currentMailClient;

	private List<string> notifications = new List<string>();

	public void RegisterMailClient(MailMessageHandler mailClient)
	{
		// ������������ �� ����������� �������, ���� �� ���
		if (currentMailClient != null)
			currentMailClient.OnMailReceived -= ShowNotification;

		currentMailClient = mailClient;

		if (currentMailClient != null)
			currentMailClient.OnMailReceived += ShowNotification;
	}

	private void ShowNotification(MailMessage message)
	{
		//Debug.Log("�����������: " + message.Subject);
		// ����� ���� ������ ����������� �����������
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
