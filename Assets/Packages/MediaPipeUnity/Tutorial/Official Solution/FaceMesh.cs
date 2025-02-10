// Copyright (c) 2021 homuler
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

// ATTENTION!: This code is for a tutorial.

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Mediapipe.Unity.Tutorial
{
  public class FaceMesh : MonoBehaviour
  {
    [SerializeField] private RawImage _screen;
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private int _fps;

    private WebCamTexture _webCamTexture;

      private IEnumerator Start()
      { 
        if (WebCamTexture.devices.Length == 0)
        {
            throw new System.Exception("Web Camera devices are not found");
        }

        var webCamDevice = WebCamTexture.devices[0];
        _webCamTexture = new WebCamTexture(webCamDevice.name, _width, _height, _fps);
        _webCamTexture.Play();

        // Wait until the camera starts properly
        yield return new WaitUntil(() => _webCamTexture.width > 16);

        // Change screen color to white
        _screen.color = UnityEngine.Color.white;

        // Ensure the camera output is rotated to vertical
        float aspectRatio = (float)_webCamTexture.width / _webCamTexture.height;
        
        // Swap width & height to make it vertical
        _screen.rectTransform.sizeDelta = new Vector2(_height, _height / aspectRatio);

        // Rotate the camera feed by 90 degrees to make it vertical
        _screen.rectTransform.localEulerAngles = new Vector3(0, 0, -90);

        // Apply the webcam texture
        _screen.texture = _webCamTexture;
    }

    private void OnDestroy()
    {
      if (_webCamTexture != null)
      {
        _webCamTexture.Stop();
      }
    }
  }
}
