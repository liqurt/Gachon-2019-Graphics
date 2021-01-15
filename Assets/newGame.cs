using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newGame : MonoBehaviour {
    public void ChangeFirstScene() // 이거는 버튼 누르면 시행됨
    {
        SceneManager.LoadScene("scene1"); //scene1를 로드함.(씬1은 플레이 할떄 나오는 그 씬) 
    }
}
