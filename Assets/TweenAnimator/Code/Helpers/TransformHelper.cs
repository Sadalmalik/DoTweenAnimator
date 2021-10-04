using UnityEditor;
using UnityEngine;

namespace Kaleb.TweenAnimator
{
    public static class TransformHelper
    {
        public static FloatSetter GetTransformFloatSetter(
            TransformDataType type,
            Transform target,
            bool local)
        {
            FloatSetter setter = null;

            if (local)
            {
                switch (type)
                {
                    case TransformDataType.PositionX:
                        setter = value => target.localPosition = target.localPosition.SetX(value);
                        break;
                    case TransformDataType.PositionY:
                        setter = value => target.localPosition = target.localPosition.SetY(value);
                        break;
                    case TransformDataType.PositionZ:
                        setter = value => target.localPosition = target.localPosition.SetZ(value);
                        break;

                    case TransformDataType.RotationX:
                        setter = value =>
                            target.localRotation = Quaternion.Euler(target.localRotation.eulerAngles.SetX(value));
                        break;
                    case TransformDataType.RotationY:
                        setter = value =>
                            target.localRotation = Quaternion.Euler(target.localRotation.eulerAngles.SetY(value));
                        break;
                    case TransformDataType.RotationZ:
                        setter = value =>
                            target.localRotation = Quaternion.Euler(target.localRotation.eulerAngles.SetZ(value));
                        break;
                }
            }
            else
            {
                switch (type)
                {
                    case TransformDataType.PositionX:
                        setter = value => target.position = target.position.SetX(value);
                        break;
                    case TransformDataType.PositionY:
                        setter = value => target.position = target.position.SetY(value);
                        break;
                    case TransformDataType.PositionZ:
                        setter = value => target.position = target.position.SetZ(value);
                        break;

                    case TransformDataType.RotationX:
                        setter = value =>
                            target.rotation = Quaternion.Euler(target.rotation.eulerAngles.SetX(value));
                        break;
                    case TransformDataType.RotationY:
                        setter = value =>
                            target.rotation = Quaternion.Euler(target.rotation.eulerAngles.SetY(value));
                        break;
                    case TransformDataType.RotationZ:
                        setter = value =>
                            target.rotation = Quaternion.Euler(target.rotation.eulerAngles.SetZ(value));
                        break;
                }
            }

            switch (type)
            {
                case TransformDataType.ScaleX:
                    setter = value => target.localScale = target.localScale.SetX(value);
                    break;
                case TransformDataType.ScaleY:
                    setter = value => target.localScale = target.localScale.SetY(value);
                    break;
                case TransformDataType.ScaleZ:
                    setter = value => target.localScale = target.localScale.SetZ(value);
                    break;
            }

            return setter;
        }

        public static Vector3Setter GetTransformVectorSetter(
            TransformDataType type,
            Transform target,
            bool local)
        {
            Vector3Setter setter = null;

            if (local)
            {
                switch (type)
                {
                    case TransformDataType.Position:
                        setter = value => target.localPosition = value;
                        break;

                    case TransformDataType.Rotation:
                        setter = value => target.localRotation = Quaternion.Euler(value);
                        break;
                }
            }
            else
            {
                switch (type)
                {
                    case TransformDataType.Position:
                        setter = value => target.position = value;
                        break;

                    case TransformDataType.Rotation:
                        setter = value => target.rotation = Quaternion.Euler(value);
                        break;
                }
            }

            switch (type)
            {
                case TransformDataType.Scale:
                    setter = value => target.localScale = value;
                    break;
            }

            return setter;
        }

        public static FloatSetter GetRectTransformFloatSetter(
            RectTransformDataType type,
            RectTransform target,
            bool local)
        {
            FloatSetter setter = null;

            switch (type)
            {
                case RectTransformDataType.RectSizeX:
                    setter = value => target.sizeDelta = target.sizeDelta.SetX(value);
                    break;
                case RectTransformDataType.RectSizeY:
                    setter = value => target.sizeDelta = target.sizeDelta.SetY(value);
                    break;
                case RectTransformDataType.RectPivotX:
                    setter = value => target.pivot = target.pivot.SetX(value);
                    break;
                case RectTransformDataType.RectPivotY:
                    setter = value => target.pivot = target.pivot.SetY(value);
                    break;
                case RectTransformDataType.RectAnchorMinX:
                    setter = value => target.anchorMin = target.anchorMin.SetX(value);
                    break;
                case RectTransformDataType.RectAnchorMinY:
                    setter = value => target.anchorMin = target.anchorMin.SetY(value);
                    break;
                case RectTransformDataType.RectAnchorMaxX:
                    setter = value => target.anchorMax = target.anchorMax.SetX(value);
                    break;
                case RectTransformDataType.RectAnchorMaxY:
                    setter = value => target.anchorMax = target.anchorMax.SetY(value);
                    break;
            }

            if (setter == null)
                setter = GetTransformFloatSetter((TransformDataType) type, target, local);

            return setter;
        }

        public static Vector2Setter GetRectTransformVector2Setter(
            RectTransformDataType type,
            RectTransform target,
            bool local)
        {
            Vector2Setter setter = null;

            switch (type)
            {
                case RectTransformDataType.RectSize:
                    setter = value => target.sizeDelta = value;
                    break;
                case RectTransformDataType.RectPivot:
                    setter = value => target.pivot = value;
                    break;
                case RectTransformDataType.RectAnchorMin:
                    setter = value => target.anchorMin = value;
                    break;
                case RectTransformDataType.RectAnchorMax:
                    setter = value => target.anchorMax = value;
                    break;
            }

            return setter;
        }
    }
}