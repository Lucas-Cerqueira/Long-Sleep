using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLogList : MonoBehaviour {

	public static Dictionary<string, string> dialoguesList = new Dictionary<string, string> {
		{ "medic", "Medic log #5892\n\nI never thought cryosleep could last so long. In theory we know that waking time can vary from person to person since it depends on a lot of different biological mechanisms, but I've noted three individuals who don't seem to be able to wake up anytime soon, the shortage in our staff is going to be a problem in the remaining years since we have no clue whatsoever if we are going to be able to return to our home. I guess we should call this ship our tiny little world now."},
		{ "security", "Security log #7381\n\nI believe there is a severe problem with our emergency plan. If something happens and we need to take the escape pods to leave the ship we would need clearence from the control room in order to unlock the doors. And since the only member in the ship with access to the control room is the captain, if something happens to him we would not be able to leave the ship in safety. I have no idea why nobody thought about this before and why there's even a reason to put so much power in the hands of the captain. I'm going to file a report and send it to our central."},
		{ "electrician", "Electrician log #3942\n\nThere's something wrong with the elevator wires that makes the fuse fall from it's place. I can't get why. Maybe there's something involved with the peeps from the kitchen above the generator. The eletrical power their oven demands is absurd, I think we should check on that. We also need some sort of better way for collecting solar energy if we want to keep living in this tin can. The folks from the research department are demanding more and more power everyday, if only we had permission to know what the hell is going on there it would make it easier to understand why."}
	};

}
