using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public bool isFadeInOnEnable = true;
    public bool isDisableOnFadeOut = true;

    private Renderer[] renderers;
    private MaskableGraphic[] renderersImage;
    private Color newAlphaColor = new Color();
    private float fadeTime = 0;
    private float maxFadeTime = 1.00f;

    public void OnEnable()
    {
        renderersImage = GetComponentsInChildren<MaskableGraphic>();
        if(renderersImage.Length == 0)
            renderers = GetComponentsInChildren<Renderer>();
        if(isFadeInOnEnable)
            ForseFadeIn();
    }
    public void ForseFadeOut()
    {
        fadeTime = maxFadeTime;
        StopAllCoroutines();
        if (renderersImage.Length == 0)
        {
            StartCoroutine(UpdateFadeOutRenderer());
        }
        else
        {
            StartCoroutine(UpdateFadeOutImage());
        }
    }
    public void ForseFadeIn()
    {
        StopAllCoroutines();
        fadeTime = 0f;
        if (renderersImage.Length == 0)
        {
            StartCoroutine(UpdateFadeInRenderer());
        }
        else
        {
            StartCoroutine(UpdateFadeInImage());
        }
    }
    public void FadeOut()
    {
        StopAllCoroutines();
        if (renderersImage.Length == 0)
        {
            StartCoroutine(UpdateFadeOutRenderer());
        }
        else
        {
            StartCoroutine(UpdateFadeOutImage());
        }
    }
    public void FadeIn()
    {
        StopAllCoroutines();
        if (renderersImage.Length == 0)
        {
            StartCoroutine(UpdateFadeInRenderer());
        }
        else
        {
            StartCoroutine(UpdateFadeInImage());
        }
    }
    private IEnumerator UpdateFadeOutRenderer()
    {
        while (fadeTime > 0)
        {
                foreach (Renderer rend in this.renderers)
            {
                newAlphaColor = rend.material.color;
                newAlphaColor.a = Mathf.Lerp(0, 1, fadeTime);
                rend.material.color = newAlphaColor;
            }
            yield return new WaitForFixedUpdate();
            fadeTime -= Time.fixedDeltaTime;
        }
        fadeTime = 0f;
        foreach (Renderer rend in this.renderers)
        {
            newAlphaColor = rend.material.color;
            newAlphaColor.a = 0f;
            rend.material.color = newAlphaColor;
        }
        if(isDisableOnFadeOut)
        {
            gameObject.SetActive(false);
        }
            
    }
    private IEnumerator UpdateFadeInRenderer()
    {
        while (fadeTime < maxFadeTime)
        {
            foreach (Renderer rend in this.renderers)
            {
                newAlphaColor = rend.material.color;
                newAlphaColor.a = Mathf.Lerp(0, 1, fadeTime);
                rend.material.color = newAlphaColor;
            }
            fadeTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        fadeTime = maxFadeTime;
        foreach (Renderer rend in this.renderers)
        {
            newAlphaColor = rend.material.color;
            newAlphaColor.a = 1f;
            rend.material.color = newAlphaColor;
        }
    }
    private IEnumerator UpdateFadeOutImage()
    {
        while (fadeTime > 0)
        {
            foreach (MaskableGraphic im in renderersImage)
            {
                newAlphaColor = im.color;
                newAlphaColor.a = Mathf.Lerp(0, 1, fadeTime);
                im.color = newAlphaColor;
            }
            yield return new WaitForFixedUpdate();
            fadeTime -= Time.fixedDeltaTime;
        }
        fadeTime = 0f;
        foreach (MaskableGraphic im in renderersImage)
        {
            newAlphaColor = im.color;
            newAlphaColor.a = 0f;
            im.color = newAlphaColor;
        }
        if (isDisableOnFadeOut)
        {
            gameObject.SetActive(false);
        }
    }
    private IEnumerator UpdateFadeInImage()
    {
        while (fadeTime < maxFadeTime)
        {
            foreach (MaskableGraphic im in renderersImage)
            {
                newAlphaColor = im.color;
                newAlphaColor.a = Mathf.Lerp(0, 1, fadeTime);
                im.color = newAlphaColor;
            }
            fadeTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        fadeTime = maxFadeTime;
        foreach (MaskableGraphic im in renderersImage)
        {
            newAlphaColor = im.color;
            newAlphaColor.a = 1f;
            im.color = newAlphaColor;
        }
    }
    //private void SetAlpha(float newAlphaValue)
    //{
    //    newAlphaValue = UnityEngine.Mathf.Clamp(newAlphaValue, 0, 1f);
    //    renderers = GetComponentsInChildren<Renderer>();
    //    foreach (Renderer rend in renderers)
    //    {
    //        newAlphaColor = rend.material.color;
    //        newAlphaColor.a = newAlphaValue;
    //        rend.material.color = newAlphaColor;
    //    }
    //}
}
