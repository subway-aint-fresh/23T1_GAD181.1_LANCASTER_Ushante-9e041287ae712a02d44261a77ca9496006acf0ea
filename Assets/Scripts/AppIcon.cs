using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppIcon : MonoBehaviour
{
    //public method that sets active self to false
    public void DisableIcon()
    {
        gameObject.SetActive(false);
        GameObject.Find("DesktopManager").GetComponent<AppSpawner>().CountIncrease();
    }
}
