using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kaleb.TweenAnimator
{
    public static class ColorHelper
    {
        public static ColorSetter GetImageColorSetter(ColorDataType type, Image image)
        {
            ColorSetter setter = null;

            setter = value => image.color = value;

            return setter;
        }
        
        public static FloatSetter GetImageFloatSetter(ColorDataType type, Image image)
        {
            FloatSetter setter = null;

            switch (type)
            {
                case ColorDataType.ColorR:
                    setter = value => image.color = image.color.SetR(value);
                    break;
                case ColorDataType.ColorG:
                    setter = value => image.color = image.color.SetG(value);
                    break;
                case ColorDataType.ColorB:
                    setter = value => image.color = image.color.SetB(value);
                    break;
                case ColorDataType.ColorA:
                    setter = value => image.color = image.color.SetA(value);
                    break;
            }

            return setter;
        }
    }
}