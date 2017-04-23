using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueText : MonoBehaviour {

	public static Dictionary<string, string[]> dialoguesList = new Dictionary<string, string[]> {
		{ "wakeUp", new string[]{ "Where am I?\nIs that ice on my skin?", "What happened to me?", "Looks like there is a note right there"} },
		{ "firstDoor", new string[]{ "This door is locked\nWhere does it lead to?"} } 
	};

}
