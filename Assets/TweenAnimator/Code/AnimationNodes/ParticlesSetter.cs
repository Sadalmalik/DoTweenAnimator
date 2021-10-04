using System;
using DG.Tweening;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Kaleb.TweenAnimator
{
	public class ParticlesSetter : AnimationNode
	{
		[Space]
		public ParticleSystem particles;

		public bool play = true;

		public override void AppendTo(Sequence sequence)
		{
			bool startPlay = play;
			sequence.InsertCallback(time, () =>
			{
				if (startPlay)
                {
			        Debug.Log($"[TEST] Start particles {particles.name}");
                    particles.Clear(true);
					particles.Play(true);
                }
				else
                {
			        Debug.Log($"[TEST] Stop particles {particles.name}");
					particles.Stop(true);
                    particles.Clear(true);
                }
			});
		}
	}
}