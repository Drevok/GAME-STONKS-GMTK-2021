using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
   public void LoadGame()
   {
      SceneManager.LoadScene("GAME");
   }

   public void LoadMenu()
   {
      SceneManager.LoadScene("MenuScene");
   }

}
