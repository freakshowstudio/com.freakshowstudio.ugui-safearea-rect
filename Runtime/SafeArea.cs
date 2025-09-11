
using FreakshowStudio.CreateGameObjectAttribute.Runtime;
using UnityEngine;


namespace FreakshowStudio.SafeAreaRect.Runtime
{
    /// <summary>
    /// Automatically adjusts a RectTransform to fit within the
    /// device's safe area. This component modifies the anchor points of
    /// the RectTransform to ensure UI elements remain visible and
    /// accessible within the safe area boundaries.
    /// 
    /// <para><strong>Assumptions:</strong></para>
    /// <list type="bullet">
    /// <item><description>
    /// The canvas (or any parent) is assumed to be non-scaled
    /// </description></item>
    /// <item><description>
    /// The canvas render mode is either Overlay or Camera
    /// </description></item>
    /// <item><description>
    /// For Camera render mode, the camera viewport is disregarded and
    /// full viewport coverage is assumed
    /// </description></item>
    /// </list>
    /// </summary>
    [AddComponentMenu("UI/SafeArea")]
    [CreateGameObjectMenu(
        "Safe Area",
        "UI/SafeArea",
        priority: 3000,
        requiresCanvas: true)]
    [ExecuteAlways]
    [RequireComponent(typeof(RectTransform))]
    internal sealed class SafeArea : MonoBehaviour
    {
        private RectTransform _rectTransform = null!;

        private Rect _lastSafeArea;
        private int _lastScreenWidth;
        private int _lastScreenHeight;

        private void OnEnable()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            var safeArea = Screen.safeArea;
            var screenWidth = Screen.width;
            var screenHeight = Screen.height;

            if (_lastSafeArea == safeArea &&
                _lastScreenWidth == screenWidth &&
                _lastScreenHeight == screenHeight)
            {
                return;
            }

            Apply(safeArea, screenWidth, screenHeight);

            _lastSafeArea = safeArea;
            _lastScreenWidth = screenWidth;
            _lastScreenHeight = screenHeight;
        }

        private void Apply(
            Rect safeArea,
            int screenWidth,
            int screenHeight)
        {
            var rect = new Rect(
                safeArea.xMin / screenWidth,
                safeArea.yMin / screenHeight,
                safeArea.width / screenWidth,
                safeArea.height / screenHeight);

            _rectTransform.anchorMin = new Vector2(rect.xMin, rect.yMin);
            _rectTransform.anchorMax = new Vector2(rect.xMax, rect.yMax);
        }
    }
}
