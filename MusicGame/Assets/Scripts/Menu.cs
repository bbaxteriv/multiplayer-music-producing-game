using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
  public Button MenuButton;

  // Start is called before the first frame update
  void Start()
  {
    MenuButton.onClick.AddListener(() => MenuCallBack());
  }

  void MenuCallBack()
  {
    SceneManager.LoadScene("Menu");
  }

  // Update is called once per frame
  void Update()
  {
  }
}
