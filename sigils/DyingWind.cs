using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DiskCardGame;
using UnityEngine;

namespace RegionExpansions.sigils
{
    internal class DyingWind : SpecialCardBehaviour
	{
		public SpecialTriggeredAbility SpecialAbility => specialAbility;

		public static SpecialTriggeredAbility specialAbility;

		private int numTurnsInPlay;

		public override bool RespondsToUpkeep(bool playerUpkeep)
		{
			PlayableCard card = (PlayableCard)base.Card;
			return card.OpponentCard != playerUpkeep && card.OnBoard;
		}

		public override IEnumerator OnUpkeep(bool playerUpkeep)
		{

			PlayableCard card = (PlayableCard)base.Card;
			int num = SeededRandom.Range(1, 4, GetRandomSeed());
			this.numTurnsInPlay++;
			card.Anim.LightNegationEffect();
			if (this.numTurnsInPlay >= num)
			{
				yield return card.Die(false, null, true);
			}
			yield break;
		}
	}
}
