using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
  public Button SceneButton;
  public string NewScene;

  // Start is called before the first frame update
  void Start()
  {
    SceneButton.onClick.AddListener(() => SceneCallBack());
  }

  // Load new scene
  void SceneCallBack()
  {
    SceneManager.LoadScene(NewScene);
  }
}
