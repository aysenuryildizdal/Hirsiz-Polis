using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Bu metod, d��meye bas�ld���nda �a�r�lacak
    public void ChangeToSceneAtIndex(int index)
    {
        SceneManager.LoadScene(0); // Belirtilen index'teki sahneyi y�kler
    }
}
