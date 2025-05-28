using Aspose.Email;
using MimeKit;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FullMailPrefabScript : MonoBehaviour
{
	public RawImage icon;
	public string senderText;
	public string titleText;
	public string messageText;
	public GameObject AttachmentHolder;
	public GameObject AttachmentPrefab;

	public TMP_Text sender;
	public TMP_Text title;
	public TMP_Text message;

	public MailPrefabScript mailPrefabSc;
	public MimeMessage currentMail;

	public void ChangeMail()
	{
		senderText = currentMail.From.ToString();
		titleText = currentMail.Subject.ToString();
		messageText = currentMail.TextBody.ToString();

		sender.text = senderText;
		title.text = titleText;
		message.text = messageText;

		if(currentMail.Attachments.Any())
		{
			for(int i = 0; i<currentMail.Attachments.Count(); i++) 
			{
				AttachmentHolder.SetActive(true);
				Instantiate(AttachmentPrefab, AttachmentHolder.transform);
			}
		}
	}

	public void DeleteMail()
	{
		Destroy(gameObject);
		mailPrefabSc.DeleteMail();	
	}
}
