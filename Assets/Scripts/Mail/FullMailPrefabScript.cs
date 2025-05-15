using Aspose.Email;
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

	public TMP_Text sender;
	public TMP_Text title;
	public TMP_Text message;

	public MailPrefabScript mailPrefabSc;
	public MailMessage currentMail;

	public void ChangeMail()
	{
		senderText = currentMail.From.ToString();
		titleText = currentMail.Subject.ToString();
		messageText = currentMail.Body.ToString();

		sender.text = senderText;
		title.text = titleText;
		message.text = messageText;
	}

	public void DeleteMail()
	{
		Destroy(gameObject);
		mailPrefabSc.DeleteMail();	
	}
}
