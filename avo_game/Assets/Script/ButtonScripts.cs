using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScripts : MonoBehaviour {
    public void ButtonClicked()
    {
        SceneManager.LoadScene("Map");
    }
}
