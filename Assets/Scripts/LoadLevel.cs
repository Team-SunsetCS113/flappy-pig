using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

    public void LoadAdditive(int level)
    {
        Application.LoadLevelAdditive(level);
    }
}
