using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GameGUI : MonoBehaviour {

    public Rect resetRect;
    public DefenseSelection defenseSelection;
    public Rect defenseButtonRect;
    public Rect defenseWindowRect;
    public bool showDefenseSelection;
    public MonoBehaviour[] guis;

    void OnGUI()
    {
        if (!showDefenseSelection)
        {
            if (GUI.Button(resetRect, "Restart"))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            if (GUI.Button(defenseButtonRect, "Defenses"))
            {
                showDefenseSelection = true;
            }
            foreach (var g in guis)
            {
                g.enabled = true;
            }
        }
        else
        {
            GUILayout.Window(1000, defenseWindowRect, id => {
                if (defenseSelection.DrawGUI())
                {
                    showDefenseSelection = false;
                }
            }, "Defenses");
            foreach (var g in guis)
            {
                g.enabled = false;
            }
        }
    }
}
