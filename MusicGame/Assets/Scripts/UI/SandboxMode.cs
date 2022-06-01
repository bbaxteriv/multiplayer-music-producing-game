using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandboxMode : MonoBehaviour
{
    public void SandboxModeOn()
    {
        Globals.sandboxMode = true;
    }

    public void SandboxModeOff()
    {
        Globals.sandboxMode = false;
    }
}
