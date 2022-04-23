using UnityEngine;
using UnityEngine.UIElements;

public class UiService : MonoBehaviour {
  public GameObject mainMenuGo;
  public VisualElement body;

  private bool isMenuOpen = false;

  private void Start () {
    _InitializeElements();
  }

  private void Update () {
    _CheckForInputs();
  }

  private void _InitializeElements () {
    var root = mainMenuGo.GetComponent<UIDocument>().rootVisualElement;
    body = root.Q<VisualElement>("body");
    var resumeBtn = root.Q<Button>("resume");
    resumeBtn.clicked += _ToggleMainMenu;
  }

  private void _CheckForInputs () {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      _ToggleMainMenu();
    }
  }

  private void _ToggleMainMenu () {
    isMenuOpen = !isMenuOpen;
    if (isMenuOpen) {
      body.style.display = DisplayStyle.Flex; // show menu
      Time.timeScale = 0; // pause game
    } else {
      body.style.display = DisplayStyle.None; // hide menu
      Time.timeScale = 1; // continue game
    }
  }
}