/*using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {

	public enum QuestState { Inactive, Active, Complete }

	private QuestState state;
	private string name;
	private string description;
	private List<Objective> objectives;

	public Quest (string name, string description) {
		this.state = QuestState.Inactive;
		this.name = name;
		this.description = description;
		this.objectives = new List<Objective>();
	}

	public void AddObjective (Objective objective) {
		objectives.Add (objective);
	}

	public Objective GetObjective(int index) {
		return objectives [index];
	}

	public void StartQuest() {
		this.state = QuestState.Active;
		foreach (Objective obj in objectives)
			obj.SetState (QuestState.Active);
	}

	public void CompleteQuest() {
		this.state = QuestState.Complete;
	}

	private bool CheckCompletion() {
		foreach (Objective obj in objectives) {
			if (!obj.IsComplete)
				return false;
		}
		return true;
	}


}
*/