using UnityEngine;

public class AppStart : MonoBehaviour
{
    protected NotificationManager notificationManager;

	public virtual void OnOpen()
    {

    }

    public void SetNotificationManager(NotificationManager manager)
    {
        notificationManager = manager;
    }
}
