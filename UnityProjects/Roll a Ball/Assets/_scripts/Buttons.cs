using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

    public void ChangeScene(int sceneIndex)
    {
        Application.LoadLevel(sceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
