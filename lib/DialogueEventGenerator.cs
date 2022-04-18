using System.Collections.Generic;

namespace RegionExpansions
{
	public static class DialogueEventGenerator
	{
		public static DialogueEvent GenerateEvent(string name, List<CustomLine> mainLines, List<List<CustomLine>> repeatLines, 
			DialogueEvent.MaxRepeatsBehaviour afterMaxRepeats, string groupID = "",
			DiskCardGame.TextDisplayer.LetterAnimation animationLetter = DiskCardGame.TextDisplayer.LetterAnimation.None,
			DiskCardGame.TextDisplayer.LetterAnimation animationLetterRepeat = DiskCardGame.TextDisplayer.LetterAnimation.None)
		{
			DialogueEvent dialogueEvent = new DialogueEvent();
			List<DialogueEvent.Speaker> speakers = new List<DialogueEvent.Speaker> { DialogueEvent.Speaker.Single };
			dialogueEvent.id = name;
			dialogueEvent.mainLines = new DialogueEvent.LineSet(mainLines.ConvertAll((CustomLine x) => x.ToLine(speakers)));
			dialogueEvent.mainLines.lines.ForEach(line => line.letterAnimation = animationLetter);
			dialogueEvent.repeatLines = repeatLines.ConvertAll((List<CustomLine> x) => new DialogueEvent.LineSet(x.ConvertAll((CustomLine x2) => x2.ToLine(speakers))));
			dialogueEvent.repeatLines.ForEach(line => line.lines.ForEach(lineZ => lineZ.letterAnimation = animationLetterRepeat));
			dialogueEvent.maxRepeatsBehaviour = afterMaxRepeats;
			dialogueEvent.speakers = new List<DialogueEvent.Speaker>(speakers);
			dialogueEvent.groupId = groupID;
			DialogueDataUtil.Data?.events?.Add(dialogueEvent);
			return dialogueEvent;
		}
	}
}