using UnityEngine;

public class HeightFromDiffuse : MonoBehaviour
{
    [SerializeField] GameObject heightFromDiffuseGuiObject;
    [SerializeField] HeightFromDiffuseGui heightFromDiffuseGuiScript;

    public void CreateHeightMapFromDiffuse()
    {
        heightFromDiffuseGuiObject.SetActive(true);
        heightFromDiffuseGuiScript.NewTexture();
        heightFromDiffuseGuiScript.DoStuff();
    }
}
