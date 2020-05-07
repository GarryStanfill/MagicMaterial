using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    [SerializeField] MapType mapTypeToLoad;
    [SerializeField] SaveLoadProject saveLoadProject;
    [SerializeField] FileBrowser fileBrowser;
    public Texture2D _TextureMap;
    public RenderTexture _HDTextureMap;
    public Material SampleMaterial;
    public GameObject testObject;
    public RawImage mapPreviewImage;

    public void PasteFile()
    {
        ClearTexture(mapTypeToLoad);
        saveLoadProject.PasteFile(mapTypeToLoad);
    }

    public void CopyFile()
    {
        Texture2D textureToSave = _TextureMap;
        saveLoadProject.CopyFile(textureToSave);
    }

    public void OpenFile()
    {
        SetFileMaskImage();
        fileBrowser.ShowBrowser("Open " + mapTypeToLoad  + " Map", this.OpenFile);
    }

    void OpenFile(string pathToFile)
    {
        if (pathToFile == null)
        {
            return;
        }

        // clear the existing texture we are loading
        ClearTexture(mapTypeToLoad);
        StartCoroutine(saveLoadProject.LoadTexture(mapTypeToLoad, pathToFile));
    }

    public void SetPreview()
    {
        SetPreviewMaterial(_TextureMap);
    }

    void ClearTexture(Texture2D textureToClear)
    {

        if (textureToClear)
        {
            Destroy(textureToClear);
            textureToClear = null;
        }

        Resources.UnloadUnusedAssets();
    }

    void ClearTexture(MapType mapType)
    {

        switch (mapType)
        {
            case MapType.height:
                if (_TextureMap)
                {
                    Destroy(_TextureMap);
                    _TextureMap = null;
                }
                if (_TextureMap)
                {
                    Destroy(_TextureMap);
                    _TextureMap= null;
                }
                break;
        }
        Resources.UnloadUnusedAssets();
    }

    void SetFileMaskImage()
    {
        fileBrowser.fileMasks = "*.png;*.jpg;*.jpeg;*.tga;*.bmp;*.tif";
    }

    public void SetPreviewMaterial(Texture2D textureToPreview)
    {
        //CloseWindows();
        if (textureToPreview != null)
        {
            FixSizeMap(textureToPreview);
            SampleMaterial.SetTexture("_MainTex", textureToPreview);
            testObject.GetComponent<Renderer>().material = SampleMaterial;
        }
    }

    public void SetPreviewMaterial(RenderTexture textureToPreview)
    {
        //CloseWindows();
        if (textureToPreview != null)
        {
            FixSizeMap(textureToPreview);
            SampleMaterial.SetTexture("_MainTex", textureToPreview);
            testObject.GetComponent<Renderer>().material = SampleMaterial;
        }
    }

    void FixSizeMap(Texture2D mapToUse)
    {
        FixSizeSize((float)mapToUse.width, (float)mapToUse.height);
    }

    void FixSizeMap(RenderTexture mapToUse)
    {
        FixSizeSize((float)mapToUse.width, (float)mapToUse.height);
    }

    void FixSizeSize(float width, float height)
    {
        Vector3 testObjectScale = new Vector3(1, 1, 1);
        float area = 1.0f;

        testObjectScale.x = width / height;

        float newArea = testObjectScale.x * testObjectScale.y;
        float areaScale = Mathf.Sqrt(area / newArea);

        testObjectScale.x *= areaScale;
        testObjectScale.y *= areaScale;

        testObject.transform.localScale = testObjectScale;
    }

    public void SetPreviewImage()
    {
        mapPreviewImage.GetComponent<RawImage>().texture = _TextureMap;
    }
}
