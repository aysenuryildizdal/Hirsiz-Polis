using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu3 : MonoBehaviour
{
    #region Variables
    public Canvas pauseCanvas = null;
    #endregion
    private void Start() {
        if(pauseCanvas != null){
            pauseCanvas.gameObject.SetActive(false);
        }
    }
    public void loadGame(){
        SceneManager.LoadScene(4);
    }

    public void Quit(){
        Application.Quit();
    }

    public void loadMenu(){
        SceneManager.LoadScene(10);
    }

    void Pause(){
        if(pauseCanvas != null){
            pauseCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Resume(){
        if(pauseCanvas != null){
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            pauseCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private void Update() {
        if(Input.GetKey(KeyCode.Tab)){
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Pause();
        }
    }
}
