using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationControllerUI : MonoBehaviour
{
    public List<Sprite> sprites;
    int list_iter = 0;
    public float delta_time = 1;
    public float delay = 0;
    public float iterationCount = 1;
    public bool isInLoop = false;
    public float LoopOffset = 0;
    float last_time;
    float offsetTime;
    int counter;
    bool doAnimationXTimes = true;

    // Use this for initialization
    void Start()
    {
        last_time = Time.time;
        offsetTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float current_time = Time.time;
        if (isInLoop && (current_time > last_time + LoopOffset))
        {
            last_time = Time.time;
            offsetTime = Time.time;
            doAnimationXTimes = true;
            counter = 0;
        }
        if (!doAnimationXTimes)
            return;
        if (current_time - offsetTime < delay)
            return;

        if (current_time - last_time >= delta_time)
        {
            GetComponent<Image>().sprite = sprites[list_iter];
            list_iter++;
            if (list_iter == sprites.Count)
                list_iter = 0;
            last_time = current_time;
            if(list_iter==0)
            {
                counter++;
                if(counter >= iterationCount)
                    doAnimationXTimes = false;
            }
        }

    }
}
