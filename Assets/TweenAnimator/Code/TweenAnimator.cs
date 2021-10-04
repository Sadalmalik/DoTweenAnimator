using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kaleb.TweenAnimator
{
    public class TweenAnimator : SerializedMonoBehaviour
    {
        public int loops = 1;
        public bool playOnAwake = false;

        [HorizontalGroup(group: "Components", order: 1)]
        public List<AnimationNode> nodes = new List<AnimationNode>();

        public Sequence sequence { get; private set; }
        public float Duration => sequence.Duration();

        private void Awake()
        {
            RebuildSequence();

            if (playOnAwake)
            {
                Play();
            }
        }

        [HorizontalGroup(group: "Buttons", order: 0)]
        [Sirenix.OdinInspector.Button]
        public void RebuildSequence()
        {
            sequence?.Kill();
            Debug.Log("RebuildSequence");
            sequence = DOTween.Sequence();
            sequence.SetAutoKill(false);
            sequence.SetRecyclable(true);
            foreach (var node in nodes)
                node.AppendTo(sequence);
            sequence.SetLoops(loops);
            sequence.Pause();
        }

        [HorizontalGroup(group: "Buttons", order: 0)]
        [Sirenix.OdinInspector.Button]
        public void RebuildAndPlay()
        {
            RebuildSequence();
            Play();
        }

        [HorizontalGroup(group: "Buttons", order: 0)]
        [Sirenix.OdinInspector.Button]
        public void Play()
        {
            Debug.Log("Play");
            if (sequence == null)
                RebuildSequence();
            sequence.Restart();
            sequence.Play();
        }

        public void Stop()
        {
            if (sequence == null)
                RebuildSequence();
            sequence.Restart();
            sequence.Pause();
        }
    }
}