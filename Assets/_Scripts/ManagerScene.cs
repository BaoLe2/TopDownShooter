using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    private void OnEnable() {
        Invoke("Load", 5);
    }

    protected virtual void Load(){
        SceneManager.LoadScene(1);
    }
}
