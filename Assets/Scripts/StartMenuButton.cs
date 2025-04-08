using UnityEngine;

public class StartMenuButton : MonoBehaviour
{
    bool flag = false;
    public GameObject obj;
    public void OnPress()
    {
        flag = !flag;
        if(flag)
            obj.SetActive(true);
        else 
            obj.SetActive(false);

    }
}
