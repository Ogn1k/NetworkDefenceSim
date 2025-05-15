using Aspose.Email;
using System;
using UnityEngine;

public class EmlProcessor
{
	public MailMessage LoadEml(string filePath)
	{
		try
		{
			MailMessage message = MailMessage.Load(filePath);
			return message;
		}
		catch (Exception ex)
		{
			Debug.LogError($"Ошибка загрузки EML: {ex.Message}");
			return null;
		}
	}
}
