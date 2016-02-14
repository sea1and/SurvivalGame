/*using UnityEngine;
using System.Collections;

public abstract class Objective : MonoBehaviour {
	private Quest.QuestState state;

	public Objective() {
		this.state = Quest.QuestState.Inactive;
	}

	public bool IsActive {
		get { state == Quest.QuestState.Active ? true : false; }
	}

	public bool IsComplete {
		get { state == Quest.QuestState.Complete ? true : false; }
	}

	public abstract string ObjectiveName { get; }

	public void SetState (Quest.QuestState state) {
		this.state = state; 
	}

	public abstract void Start();
}

public class ElimibationObjective : Objective {
	private string actorName;
	private int quantity;

	private string objName;

	public override string ObjectiveName {
		get { return objName; }
	}

	public string ActorName {
		get { return actorName; }
	}

	public int Quantity {
		get { return quantity; }
	}

	public override void Start() {
		
	}
}

public class CollectionObjective : Objective {
	 
}
*/