using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonButton : Button
{
    private Image buttonImage;
    private GameManager gameManager;
    
    protected override void Start()
    {
        base.Start();
        buttonImage = GetComponent<Image>();
        gameManager = FindObjectOfType<GameManager>();
        onClick.AddListener(SetPlayerButton);
    }

    private void SetPlayerButton()
    {
        gameManager.SetLatestPlayerButton(this.gameObject);
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
