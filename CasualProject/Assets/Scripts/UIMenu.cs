using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour {
    //[Header("Set in Inspector: UIMenu")]
    // [Header("Set Dynamically: UIMenu")]

    public void StartGame() {
        Game.S.StartAndOverGame(true);
    }

    public void ExitGame() {
        Application.Quit();
    }
}