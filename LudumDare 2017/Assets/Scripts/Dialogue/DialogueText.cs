using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueText : MonoBehaviour {

	public static Dictionary<string, string[]> dialoguesList = new Dictionary<string, string[]> {
		{ "wakeUp", new string[]{ "Shit...cryosleeping always makes my muscle hurts..", "Where's the doctor? Wasn't he supposed to be here at all times?"} },
		{ "medic", new string[]{ "How much did I sleep? This doesn't make sense."} },
		{ "security", new string[]{ "Yeah...bureaucracy sucks, welcome to the 31st century, pal."}},
		{ "atLounge", new string[]{ "Holy shit! I have to get out of here."}},
		{ "electrician", new string[]{ "Damn, I have to fix this fast."}},
		{ "atCoffee", new string[]{ "Where is everybody? What the hell happened here?"}},
		{ "atBasement", new string[]{ "We should have way more supplies than this...how many years have I slept?"}},
		{ "afterFixingFuse", new string[]{ "Alright, we still have time."}},
		{ "atCaptain", new string[]{ "Wow, look at this view.\nHome...it looks so small from here."}},
		{ "afterPickingCard", new string[]{ "Ok, let's finish this."}},
		{ "afterOpeningEscapePodRoom", new string[]{ "Finally!"}},
		{ "insideEscapePod", new string[]{ "Home...so distant...so small..."}}

	};

}
