using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTracking : MonoBehaviour
{
    public string ReferenceImageName;
    private ARTrackedImageManager _TrackedImageManager;

    private void Awake()
    {
        _TrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        if (_TrackedImageManager != null)
        {
            _TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        }
    }

    private void OnDisable()
    {
        if (_TrackedImageManager != null)
        {
            _TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }
    }

    private void OnTrackedImagesChanged()
    {
        foreach (var trackedImage in e.added)
        {
            Debug.Log($"Traked image detected: {trackedImage.referenceImage.name} with size: {trackedImage.size}");
        }

        UpdateTrackedImages(e.added);
        UpdateTrackedImages(e.updated);

    }

    private void UpdateTrackedImages(IEnumerable<ARTrackedImage> trackedImages)
    {
        var trackedImage = trackedImages.FirstOrDefault(x => x.referenceImage.name == ReferenceImageName);
        if (trackedImage == null)
        {
            return;
        }
    }

}
