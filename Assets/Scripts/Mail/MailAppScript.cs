using UnityEngine;

public class MailAppScript : DefaultAppScript
{
	public MailSaveController mailSaveController;

	public override void CloseAppF()
	{
		mailSaveController.UpdateSave();
		base.CloseAppF();
	}
}
