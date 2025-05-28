using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Aspose.Email;
using MimeKit;
using UnityEngine;
public class MailMessageHandler : MonoBehaviour
{
	public MailSaveObj mailBoxSave;
	//public List<string> mailMessagesSTRlist = new List<string>();
	//public List<MailMessage> mailMessages = new List<MailMessage>();
	//public List<MailMessage> MailMessagesDeleted = new List<MailMessage>();
	public MailClientManager mailClientManager;
	public MailSaveController mailSaveController;

	public GameObject mailPrefab;
	public Transform mailPrefabContext;
	public Transform fullMailPrefabContext;

	public List<MimeMessage> messages = new List<MimeMessage>();

	public event Action<MimeMessage> OnMailReceived;

	private void Start()
	{
		//instance = this;
		//mailMessages = new List<MailMessage>();
		//MailMessagesDeleted = new List<MailMessage>();
		mailSaveController.LoadSave();
		mailBoxSave = mailSaveController.saveFile;
		UpdateMailBox();
	}

	public void SendMail(int id)
	{
		MimeMessage mail = GetMail(id);

		if (mailBoxSave == null)
		{
			mailBoxSave = mailSaveController.saveFile;
		}
		//print(mail.From);
		mailBoxSave.savedMails.Add(mail);
		mailBoxSave.savedMailsSTR.Add(mail.Subject);
		InstantiateEmail(mail);
		OnMailReceived?.Invoke(mail);
	}

	public void InstantiateEmail(MimeMessage mail)
	{
		GameObject mailPreview = Instantiate(mailPrefab, mailPrefabContext);
		MailPrefabScript mailPrefabSc = mailPreview.GetComponent<MailPrefabScript>();
		mailPrefabSc.mailBox = this;
		mailPrefabSc.SetMail(mail);
		mailPrefabSc.ChangeMail();
		messages.Add(mail);
	}

	public MimeMessage GetMail(int id) 
	{
		return mailClientManager.instance.loadedEmails.ElementAt(id);
	}

	public MimeMessage GetLastMail()
	{
		return mailBoxSave.savedMails.Last();
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


	public void DeleteMessage(MimeMessage mail)
	{
		//MailMessagesDeleted.Add(mail);
		mailBoxSave.savedMails.Remove(mail);
		mailBoxSave.savedDeletedMailsSTR.Remove(mail.Subject);
	}

	public void UpdateMailBox()
	{
		if (mailBoxSave == null)
			return;

		foreach (MimeMessage mail in mailBoxSave.savedMails) 
		{
			if(!messages.Contains(mail))
				InstantiateEmail(mail);
		}
	}

}
