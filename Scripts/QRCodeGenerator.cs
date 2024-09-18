using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using TMPro;
using UnityEditor.UI;
using System.Runtime.CompilerServices;
using UnityEngine.UI;

public class QRCodeGenerator : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImageReceiver;
    [SerializeField]
    private TMP_InputField _textInputField;

    private Texture2D _storEncodedTexture;

    void Start()
    {
        _storEncodedTexture =  new Texture2D(256, 256);
    }

    private Color32 [] Encode(string textForEncoding,int width,int height)
    {
        BarcodeWriter writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            } 
        };
        return writer.Write(textForEncoding);
    }

    public void OnClickEncode()
    {
        EncodeTextToQRCode();
    }
    private void EncodeTextToQRCode()
    {
        string textWrite = string.IsNullOrEmpty(_textInputField.text) ?("you Should Write Something") : _textInputField.text;
        Color32[] _convertPixelToTexture = Encode(textWrite, _storEncodedTexture.width, _storEncodedTexture.height);
        _storEncodedTexture.SetPixels32(_convertPixelToTexture);
        _storEncodedTexture.Apply();

        _rawImageReceiver.texture = _storEncodedTexture;
    }
}
