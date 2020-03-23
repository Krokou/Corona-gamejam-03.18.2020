using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrunkCountDown : MonoBehaviour
{
    public GameObject drunkAircountDown;
    public TextMeshProUGUI drunkcountDownText;
    private float deltaTime = 0;
    public Animator drunkanimator;
    public int drunkcounterMax = 10;
    public int drunkdisplayLetter;
    public bool drunkdone = true;

    // Update is called once per frame
    void Update()
    {
        if (!drunkdone)
        {
            deltaTime += Time.deltaTime;
            drunkdisplayLetter = (int)(drunkcounterMax - deltaTime + 0.99f);
            DrunkUpdateCountDown();

            if (deltaTime >= drunkcounterMax)
            {
                drunkdisplayLetter = 0;
                drunkdone = true;
            }
        }
        if (drunkdisplayLetter <= 3)
        {
            drunkanimator.SetBool("Under3s", true);
        }
        else
        {
            drunkanimator.SetBool("Under3s", false);
        }
    }
    public void DrunkResetCounter()
    {
        drunkdone = false;
        deltaTime = 0;
    }
    public void DrunkUpdateCountDown()
    {
        drunkcountDownText.text = drunkdisplayLetter.ToString() + "s";
    }
}
    //end of drunk stuff

