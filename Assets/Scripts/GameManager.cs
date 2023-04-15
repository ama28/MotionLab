using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject trackerCanvas;
    public GameObject line;
    private bool canvasShowing;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.T)) {
             canvasShowing = !canvasShowing;
             trackerCanvas.SetActive(canvasShowing);
             line.SetActive(canvasShowing);
         }
    }
}
