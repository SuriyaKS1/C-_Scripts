using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class QrcodeScript : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImageBackground;


   
    [SerializeField]
    private AspectRatioFitter _aspectRatioFitter;
    [SerializeField]
    private TextMeshProUGUI _textOut;
    [SerializeField]
    private RectTransform _scanZone;

    private bool _isCamAvaible;
    private WebCamTexture _cameraTexture;

    private Animation _animation;
    private bool _isanimating = false;
  //  private float yPosition;
  //  private float xPosition;

    void Start()
    {
        SetUpCamera();

        _animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isanimating)
        {
            UpdateCameraRender();

            Scan();
        }
      
    }
   
    private void SetUpCamera()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            _isCamAvaible = false;
            return;
        }
        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing == false)
            {
                _cameraTexture = new WebCamTexture(devices[i].name, (int)_scanZone.rect.width, (int)_scanZone.rect.height);

                
                // Adjust the scanning zone size based on camera texture size
              
               // _scanZone.anchoredPosition = new Vector2(xPosition, yPosition);
                break;
            }
        }
        _cameraTexture.Play();
        _rawImageBackground.texture = _cameraTexture;
        _isCamAvaible = true;
    }
   
    private void UpdateCameraRender()
    {
        if (_isCamAvaible == false)
        {
            return;
        }
        float ratio = (float)_cameraTexture.width / (float)_cameraTexture.height;
        _aspectRatioFitter.aspectRatio = ratio;

        _scanZone.sizeDelta = new Vector2(_cameraTexture.width, _cameraTexture.height);

        int orientation = _cameraTexture.videoRotationAngle;
        orientation = orientation * 3;
        _rawImageBackground.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);

    }

    
    public void OnClickScan()
    {
        Scan();
    }
    private void Scan()
    {
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode(_cameraTexture.GetPixels32(), _cameraTexture.width, _cameraTexture.height);
            if (result != null)
            {

                string sceneToLoad = GetSceneToLoad(result.Text);
                if (!string.IsNullOrEmpty(sceneToLoad))
                {
                    //_textOut.text = result.Text;
                    SceneManager.LoadScene(sceneToLoad);
                }

                else
                {
                    _textOut.text = result.Text;
                } 
            }
            else
            {
                _textOut.text = "Failed to Read QR CODE";
            }
        }
        catch
        {
            _textOut.text = "FAILED IN TRY";
        }
    }

    private void PlayAnimation()
    {
        _animation.Play();
        _isanimating = true;

        Invoke("StartScanning", _animation.clip.length);
    }

    private void StartScanning()
    {
        _isanimating = false;
    }

    private string GetSceneToLoad(string qrCodeText)
    {
        if (qrCodeText == "Panel01")
        {
            return "Panel01";

        }else if(qrCodeText == "Panel02")
        {
            return "Panel02";

        }
        else if (qrCodeText == "Panel03")
        {
            return "Panel03";

        }
        else if (qrCodeText == "Panel04")
        {
            return "Panel04";

        }
        else
        {
            return null;
        }
    }
    public void openlink()
    {
        Application.OpenURL(_textOut.text);
    }

    public void back()
    {
        SceneManager.LoadScene("Login");
        
    }
}
