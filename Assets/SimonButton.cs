using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonButton : Button
{
    private Image buttonImage;
    
    protected override void Start()
    {
        base.Start();
        buttonImage = GetComponent<Image>();
    }

    public void AIClick()
    {
        StartCoroutine(ChangeColorOnAIClick(0.5f));
    }

    private IEnumerator ChangeColorOnAIClick(float time)
    {
        Color initialColor = colors.normalColor;
        image.color = colors.pressedColor;
        yield return new WaitForSeconds(time);
        image.color = initialColor;
    }
}
