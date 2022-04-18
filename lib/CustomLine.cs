using DiskCardGame;
using System;
using System.Collections.Generic;

namespace RegionExpansions
{
	public class CustomLine
	{
		//Made from SAPI's dialogue code
		public DialogueEvent.Line ToLine(List<DialogueEvent.Speaker> speakers)
		{
			bool flag = !speakers.Contains(this.speaker);
			if (flag)
			{
				speakers.Add(this.speaker);
			}
			return new DialogueEvent.Line
			{
				p03Face = this.p03Face,
				emotion = this.emotion,
				letterAnimation = this.letterAnimation,
				speakerIndex = speakers.IndexOf(this.speaker),
				text = (this.text ?? ""),
				specialInstruction = (this.specialInstruction ?? ""),
				storyCondition = this.storyCondition,
				storyConditionMustBeMet = this.storyConditionMustBeMet
			};
		}


		public static implicit operator CustomLine(string str)
		{
			return new CustomLine
			{
				text = str
			};
		}


		public static implicit operator CustomLine(ValueTuple<string, TextDisplayer.LetterAnimation, Emotion> param)
		{
			return new CustomLine
			{
				text = param.Item1,
				emotion = param.Item3,
				letterAnimation = param.Item2
			};
		}

		public static implicit operator CustomLine(ValueTuple<string, TextDisplayer.LetterAnimation> param)
		{
			return new CustomLine
			{
				text = param.Item1,
				letterAnimation = param.Item2
			};
		}

		public static implicit operator CustomLine(ValueTuple<string, TextDisplayer.LetterAnimation, DialogueEvent.Speaker> param)
		{
			return new CustomLine
			{
				text = param.Item1,
				speaker = param.Item3,
				letterAnimation = param.Item2
			};
		}

		public static implicit operator CustomLine(ValueTuple<string, TextDisplayer.LetterAnimation, DialogueEvent.Speaker, Emotion> param)
		{
			return new CustomLine
			{
				text = param.Item1,
				speaker = param.Item3,
				letterAnimation = param.Item2,
				emotion = param.Item4
			};
		}

		public static implicit operator CustomLine(ValueTuple<string, Emotion> param)
		{
			return new CustomLine
			{
				text = param.Item1,
				emotion = param.Item2
			};
		}

		public static implicit operator CustomLine(ValueTuple<string, Emotion, DialogueEvent.Speaker> param)
		{
			return new CustomLine
			{
				text = param.Item1,
				speaker = param.Item3,
				emotion = param.Item2
			};
		}

		public static implicit operator CustomLine(ValueTuple<string, DialogueEvent.Speaker> param)
		{
			return new CustomLine
			{
				text = param.Item1,
				speaker = param.Item2
			};
		}

		public P03AnimationController.Face p03Face;

		public Emotion emotion;

		public TextDisplayer.LetterAnimation letterAnimation;

		public DialogueEvent.Speaker speaker;

		public string text;

		public string specialInstruction;

		public StoryEvent storyCondition = StoryEvent.BasicTutorialCompleted;

		public bool storyConditionMustBeMet;
	}
}