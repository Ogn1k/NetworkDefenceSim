using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Email;
using MimeKit;
using UnityEngine;

public class MailClientManager : MonoBehaviour
{
	public List<MimeMessage> loadedEmails { get; private set; }
	private EmlProcessor emlProcessor;
	public MailClientManager instance;
	public List<MimeMessage> LoadAllEmlFromFolder(string folderPath)
	{
		List<MimeMessage> emails = new List<MimeMessage>();

		// Получаем все файлы с расширением .eml
		string[] emlFiles = Directory.GetFiles(folderPath, "*.eml");

		foreach (string emlFile in emlFiles)
		{
			try
			{
				// Загружаем письмо из файла
				MimeMessage message = MimeMessage.Load(emlFile);
				if (message.Attachments.Any()) { print($"@{message.Subject}@ has attachments"); }
				emails.Add(message);
			}
			catch (System.Exception ex)
			{
				Debug.LogError($"Ошибка загрузки файла {emlFile}: {ex.Message}");
			}
		}

		return emails;
	}

	void Start()
	{
		instance = this;

		string folderPath = Application.dataPath + "/StreamingAssets/Emails"; // Путь к папке с EML
		loadedEmails = LoadAllEmlFromFolder(folderPath);

		Debug.Log($"Загружено писем: {loadedEmails.Count}");
	}
}
