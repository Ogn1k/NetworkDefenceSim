using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Aspose.Email;
using UnityEngine;
public class MailMessageHandler : MonoBehaviour
{
	public List<string> mailMessagesSTRlist = new List<string>();
	public List<MailMessage> mailMessages = new List<MailMessage>();
	public List<MailMessage> MailMessagesDeleted = new List<MailMessage>();
	public MailClientManager mailClientManager;
	public MailSaveController mailSaveController;

	public GameObject mailPrefab;
	public Transform mailPrefabContext;
	public Transform fullMailPrefabContext;

	public event Action<MailMessage> OnMailReceived;

	private void Start()
	{
		//instance = this;
		//mailMessages = new List<MailMessage>();
		//MailMessagesDeleted = new List<MailMessage>();
		mailSaveController.LoadSave();
		UpdateMailBox();
	}

	public void SendMail(int id)
	{
		MailMessage mail = GetMail(id);

		if (mailMessages == null)
		{ 
			mailMessagesSTRlist = new List<string>();
			mailMessages = new List<MailMessage>();
			MailMessagesDeleted = new List<MailMessage>();
		}
		mailMessages.Add(mail);
		mailMessagesSTRlist.Add(mail.Subject);
		InstantiateEmail(mail);
		OnMailReceived?.Invoke(mail);
	}

	public void InstantiateEmail(MailMessage mail)
	{
		GameObject mailPreview = Instantiate(mailPrefab, mailPrefabContext);
		MailPrefabScript mailPrefabSc = mailPreview.GetComponent<MailPrefabScript>();
		mailPrefabSc.mailBox = this;
		mailPrefabSc.SetMail(mail);
		mailPrefabSc.ChangeMail();
	}

	public MailMessage GetMail(int id) 
	{
		return mailClientManager.instance.loadedEmails.ElementAt(id);
	}

	public MailMessage GetLastMail()
	{
		return mailMessages.Last();
	}
	System.Random r = new System.Random();
	public void SendRandomMail()
	{
		
		SendMail(r.Next(0, mailClientManager.loadedEmails.Count));
	}

	public int minTime = 1;
	public int maxTime = 5;
	private Coroutine timerCoroutine;

	public void StartRandomTimer()
	{
		if (timerCoroutine != null)
			StopCoroutine(timerCoroutine);

		timerCoroutine = StartCoroutine(TimerCoroutine());
	}
	System.Random ra = new System.Random();
	IEnumerator TimerCoroutine()
	{
		
		while (true)
		{
			// Выбираем случайный интервал
			float waitTime = ra.Next(minTime, maxTime);
			yield return new WaitForSeconds(waitTime);

			// Событие по срабатыванию таймера
			SendRandomMail();

			// После срабатывания цикл повторится - таймер сбрасывается и запускается заново
		}
	}
	public void StopTimer()
	{
		if (timerCoroutine != null)
		{
			StopCoroutine(timerCoroutine);
			timerCoroutine = null;
		}
	}


	public void DeleteMessage(MailMessage mail)
	{
		//MailMessagesDeleted.Add(mail);
		mailMessages.Remove(mail);
		mailMessagesSTRlist.Remove(mail.Subject);
	}

	public void UpdateMailBox()
	{
		if (mailMessages == null)
			return;

		foreach (MailMessage mail in mailMessages) 
		{
			InstantiateEmail(mail);
		}
	}

}
