using MimeKit;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class MailBackground : MonoBehaviour
{
	public MailSaveObj mailBoxSave;
	public MailClientManager mailClientManager;
	public NotificationManager notificationManager;

	public event Action<MimeMessage> OnMailReceived;

	public int initialDelay = 3;
	public int minTime = 3;
	public int maxTime = 6;
	float interval = 4;
	public int repeat = 5;
	int repeatCount = 0;
	System.Random ra = new System.Random();
	System.Random r = new System.Random();

	public void Start()
	{
		mailBoxSave.CleanUp();
		//StartCoroutine(ActionRoutine());
		interval = ra.Next(minTime, maxTime);
		InvokeRepeating("SendMailAtTimes", initialDelay, interval);
		notificationManager.RegisterMailBackground(this);
	}

	public void SendMail(int id)
	{
		MimeMessage mail = GetMail(id);

		if (mailBoxSave == null)
		{
			print("no save file");
		}
		//print(mail.From);
		mailBoxSave.savedMails.Add(mail);
		mailBoxSave.savedMailsSTR.Add(mail.Subject);
		//InstantiateEmail(mail);
		OnMailReceived?.Invoke(mail);
	}

	public MimeMessage GetMail(int id)
	{
		return mailClientManager.instance.loadedEmails.ElementAt(id);
	}

	public void SendRandomMail()
	{
		SendMail(r.Next(0, mailClientManager.loadedEmails.Count));
	}

	IEnumerator ActionRoutine()
	{

		yield return new WaitForSeconds(initialDelay);
		for (int i = 0; i < repeatCount; i++)
		{
			float timer = 0f;

			while(timer < 3)
			{
				timer += Time.deltaTime;
				SendRandomMail();
				yield return null;
			}

			if (i < repeatCount - 1)
			{
				float interval = ra.Next(minTime, maxTime);
				yield return new WaitForSeconds(5);
			}	
		}
	}
	void SendMailAtTimes()
	{
		SendRandomMail();
		interval = ra.Next(minTime, maxTime);
		repeatCount++;
		if(repeatCount>=repeat)
			CancelInvoke("SendMailAtTimes");
	}
}
