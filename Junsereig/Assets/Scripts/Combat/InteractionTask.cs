using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionTask : MonoBehaviour
{
    public UnityEvent task;

    public void CallTask()
    {
        task.Invoke();
    }
}
