using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAlbum : MonoBehaviour
{
    [SerializeField] List<Sprite> _sprites;
    [SerializeField] Image _image;

    int _currentIndex = 0;

    public void Next()
    {
        if (_currentIndex >= _sprites.Count - 1)
        {
            return;
        }
        _currentIndex++;
        _image.sprite = _sprites[_currentIndex];
    }

    public void Previous()
    {
        if (_currentIndex <= 0)
        {
            return;
        }
        _currentIndex--;
        _image.sprite = _sprites[_currentIndex];
    }

    public void SetIndex(int index)
    {
        if (index >= 0 && index < _sprites.Count)
        {
            _currentIndex = index;
            _image.sprite = _sprites[_currentIndex];
        }
    }

    private void Start()
    {
        if (_sprites.Count > 0)
        {
            _image.sprite = _sprites[_currentIndex];
        }

        SetIndex(0);
    }
}
