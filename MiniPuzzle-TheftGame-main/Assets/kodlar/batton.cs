using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Bu metod, düðmeye basýldýðýnda çaðrýlacak
    public void ChangeToSceneAtIndex(int index)
    {
        SceneManager.LoadScene(0); // Belirtilen index'teki sahneyi yükler
    }
}
