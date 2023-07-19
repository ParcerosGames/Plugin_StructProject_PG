using UnityEngine;

public class LightHierarchy : MonoBehaviour
{
    [HideInInspector] public Color colorHierarchy;
    [HideInInspector] public Color colorText;
    [HideInInspector] public FontStyle styleText;

    public static readonly Color DEFAULT_BACKGROUND_COLOR = new Color(0.76f, 0.76f, 0.76f, 1f);

    public LightHierarchy(Color inBackgroundColor, Color inTextColor, FontStyle inFontStyle = FontStyle.Normal)
    {
        colorHierarchy = inBackgroundColor;
        colorText = inTextColor;
        styleText = inFontStyle;
    }
}
