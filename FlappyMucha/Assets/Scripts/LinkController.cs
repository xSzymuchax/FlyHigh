using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkController : MonoBehaviour
{
    public string URL;

    public void OpenLink()
    {
        Application.OpenURL(URL);
    }


}
