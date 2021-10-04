using DG.Tweening;
using DG.Tweening.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kaleb.TweenAnimator
{
    public class TransformAnimator : AnimationNode
    {
        public float duration;

        [DrawWithUnityAttribute]
        public AnimationCurve curve = new AnimationCurve();

        [Space]
        public Transform target;

        public TransformDataType type;
        public bool local;

        [Space]
        public bool useSourceTransform;

        [ShowIf("@!useSourceTransform && DataTypesExtensions.IsVector1(type)")]
        public float floatStartValue;

        [ShowIf("@!useSourceTransform && DataTypesExtensions.IsVector1(type)")]
        public float floatEndValue;

        [ShowIf("@!useSourceTransform && DataTypesExtensions.IsVector3(type)")]
        public Vector3 vectorStartValue;

        [ShowIf("@!useSourceTransform && DataTypesExtensions.IsVector3(type)")]
        public Vector3 vectorEndValue;

        [ShowIf("@useSourceTransform")]
        public Transform startAnchor;

        [ShowIf("@useSourceTransform")]
        public Transform endAnchor;

        public override void AppendTo(Sequence sequence)
        {
            if (type.IsVector3())
            {
                var assigner = TransformHelper.GetTransformVectorSetter(type, target, local & !useSourceTransform);
                if (useSourceTransform)
                {
                    vectorStartValue = startAnchor.position;
                    vectorEndValue = endAnchor.position;
                }

                float value = 0f;
                DOGetter<float> getter = () => value;
                DOSetter<float> setter = val =>
                {
                    value = val;
                    Vector3 evaluate = Vector3.LerpUnclamped(vectorStartValue, vectorEndValue, curve.Evaluate(val));
                    assigner(evaluate);
                };
                sequence.Insert(time, DOTween.To(getter, setter, 1, duration));
            }
            else
            {
                var assigner = TransformHelper.GetTransformFloatSetter(type, target, local);

                float value = 0f;
                DOGetter<float> getter = () => value;
                DOSetter<float> setter = val =>
                {
                    value = val;
                    float evaluate = Mathf.LerpUnclamped(floatStartValue, floatEndValue, curve.Evaluate(val));
                    assigner(evaluate);
                };
                sequence.Insert(time, DOTween.To(getter, setter, 1, duration));
            }
        }
    }
}