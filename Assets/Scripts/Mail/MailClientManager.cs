using System.Collections.Generic;
using System.IO;
using Aspose.Email;
using UnityEngine;

public class MailClientManager : MonoBehaviour
{
	public List<MailMessage> loadedEmails { get; private set; }
	private EmlProcessor emlProcessor;
	public MailClientManager instance;
	public List<MailMessage> LoadAllEmlFromFolder(string folderPath)
	{
		List<MailMessage> emails = new List<MailMessage>();

		// �������� ��� ����� � ����������� .eml
		string[] emlFiles = Directory.GetFiles(folderPath, "*.eml");

		foreach (string emlFile in emlFiles)
		{
			try
			{
				// ��������� ������ �� �����
				MailMessage message = MailMessage.Load(emlFile);
				emails.Add(message);
			}
			catch (System.Exception ex)
			{
				Debug.LogError($"������ �������� ����� {emlFile}: {ex.Message}");
			}
		}

		return emails;
	}

	void Start()
    {
		instance = this;

		string folderPath = Application.dataPath + "/Emails"; // ���� � ����� � EML
		loadedEmails = LoadAllEmlFromFolder(folderPath);

		Debug.Log($"��������� �����: {loadedEmails.Count}");

		/*emlProcessor = new EmlProcessor();
		string emlFilePath = Application.dataPath + "/Emails/Test email title.eml";
		MailMessage message = emlProcessor.LoadEml(emlFilePath);

		if (message != null)
		{
			// ������� ���� � ���� ������ � ������� Unity
			Debug.Log("Subject: " + message.Subject);
			Debug.Log("From: " + message.From);
			Debug.Log("Body: " + message.Body);

			// ����� ����� ���������� ��������, ���� �����
			foreach (var attachment in message.Attachments)
			{
				Debug.Log("Attachment: " + attachment.Name);
				// �������������� ������ ��� ������ � ����������
			}
		}
		else
		{
			Debug.LogError("�� ������� ��������� EML-����.");
		}*/
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
