using Aspose.Email;
using MimeKit;
using System.Linq;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class StringExt
{
	public static string? Truncate(this string? value, int maxLength, string truncationSuffix = "…")
	{
		return value?.Length > maxLength
			? value.Substring(0, maxLength) + truncationSuffix
			: value;
	}
}

public class MailPrefabScript : MonoBehaviour
{
	public MailMessageHandler mailBox;

	public RawImage icon;
    public string senderText;
    public string previewTitleText;
    public string previewMessageText;

	public TMP_Text sender;
	public TMP_Text previewTitle;
	public TMP_Text previewMessage;

    public GameObject attachmentIcon;

    private MimeMessage currentMail;

    public GameObject fullMailPrefab;
    public Transform fullMailPrefabContext;

    private GameObject fullMail;


	public void SetMail(MimeMessage mail)
    { currentMail = mail; }

	public void ChangeMail()
    {
        fullMailPrefabContext = mailBox.fullMailPrefabContext;

		senderText = currentMail.From.ToString().Truncate(10);
        previewTitleText = currentMail.Subject.ToString().Truncate(10);
        previewMessageText = currentMail.TextBody.ToString().Truncate(10);

        if (currentMail.Attachments.Any()) 
        {
            attachmentIcon.SetActive(true);
		}

        sender.text = senderText;
        previewTitle.text = previewTitleText;
        previewMessage.text = previewMessageText;
    }

    public void DeleteMail()
    {
        mailBox.DeleteMessage(currentMail);
        Destroy(gameObject);
        if (fullMail)
            Destroy(fullMail);
    }

    public void OpenFullMail()
    {
        for(int i=0; i< fullMailPrefabContext.childCount; i++) 
        {
            Destroy(fullMailPrefabContext.GetChild(i).gameObject);
		}
        
        fullMail = Instantiate(fullMailPrefab, fullMailPrefabContext);
        FullMailPrefabScript fullmailSc = fullMail.GetComponent<FullMailPrefabScript>();
        fullmailSc.mailPrefabSc = this;
        fullmailSc.currentMail = currentMail;
        fullmailSc.ChangeMail();
    }

	private void Update()
	{
        
		//ChangeMail();
	}
}
