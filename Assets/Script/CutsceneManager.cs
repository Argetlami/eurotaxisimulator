using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Cutscene manager.
/// </summary>
public class CutsceneManager : MonoBehaviour
{
	//Fields
	int i = 0;
	Button skip;
	GameObject bubble1;
	GameObject bubble2;
	GameObject canvas;
	GameObject passenger1;
	GameObject passenger2;
	GameObject passenger3;
	GameObject boaty;
	Text main;
	Text pass;
	GameObject skipTitle;
	Vector3 skipTitlepos = new Vector3 (15, -75, 0);
	Vector3 b1pos = new Vector3 (-150, 110, 0);
	Vector3 b2pos = new Vector3 (150, 110, 0);
	Vector3 b3pos = new Vector3 (-150, 110, 0);
	Boolean forward = false;
	Boolean skipped = false;
	public LayerMask taxi;
	public LayerMask ground;

	/// <summary>
	/// At the start of this instance.
	/// </summary>
	void Start ()
	{
		bubble1 = GameObject.Find ("BubbleMain");
		bubble2 = GameObject.Find ("BubblePassenger");
		skip = GameObject.Find ("Skip").GetComponent<Button> ();
        canvas = GameObject.Find ("CutsceneCanvas");
		main = GameObject.Find ("MainText").GetComponent<Text> ();
		pass = GameObject.Find ("PassengerText").GetComponent<Text> ();
		skipTitle = GameObject.Find ("PressScreenToContinue");
		passenger1 = GameObject.Find ("passenger1");
		passenger1.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		passenger2 = GameObject.Find ("passenger2");
		passenger2.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		passenger3 = GameObject.Find ("passenger3");
		passenger3.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		boaty = GameObject.Find ("Boat");
		Debug.Log ("Logged");
	}

	/// <summary>
	/// // FixedUpdate is called multiple times in a second; unlike Update(), it's based on time, not frames
	/// </summary>
	void FixedUpdate ()
	{
		skip.onClick.AddListener (() => Skip ());
	}

	/// <summary>
	/// Skip the speech bubble or an event.
	/// </summary>
	void Skip ()
	{
		forward = true;
	}

	/// <summary>
	/// Raises the trigger enter2d event.
	/// </summary>
	/// <param name="other">What collides with the cutscene-area</param>
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "taxi") {
			Debug.Log ("Collided, i = " + i);
			switch (i) {
			case 0:
				StartCoroutine (PlayFirst ());
				break;
			case 1:
				StartCoroutine (PlaySecond ());
				break;
			case 2:
				StartCoroutine (PlayThird ());
				break;
			case 3:
				StartCoroutine (PlayFourth ());
				break;
			case 4:
				StartCoroutine (PlayFifth ());
				break;
			case 5:
				StartCoroutine (PlaySixth ());
				break;
			case 6:
				StartCoroutine (PlaySeventh ());
				break;
			case 7:
				StartCoroutine (PlayEighth ());
				break;
			default:
				Debug.Log ("Error Playing Cutscene! Invalid value: " + i);
				break;
			}
		}
	}

	/// <summary>
	/// Handles the appearance and the disappearance of the players speech bubble, bubble is visible until "Skip()" is triggered.
	/// </summary>
	/// <param name="speech">Text to enter in the bubble</param>
	IEnumerator MainBubble (String speech)
	{
		forward = false;
		GameObject a = Instantiate (bubble1);
		a.transform.SetParent (canvas.transform, false);
		a.transform.localPosition = b1pos;
		GameObject b = Instantiate (skipTitle);
		b.transform.SetParent (canvas.transform, false);
		b.transform.localPosition = skipTitlepos;
		main = a.transform.Find ("MainText").GetComponent<Text> ();
		main.text = speech;
        skip.transform.SetAsLastSibling();
		while (!forward)
			yield return null;
		Destroy (a);
		Destroy (b);
	}

	/// <summary>
	/// Handles the appearance and the disappearance of the passengers speech bubble, bubble is visible until "Skip()" is triggered.
	/// </summary>
	/// <param name="speech">Text to enter in the bubble</param>
	IEnumerator PassBubble (String speech)
	{
		forward = false;
		GameObject a = Instantiate (bubble2);
		a.transform.SetParent (canvas.transform, false);
		a.transform.localPosition = b2pos;
		GameObject b = Instantiate (skipTitle);
		b.transform.SetParent (canvas.transform, false);
		b.transform.localPosition = skipTitlepos;
		pass = a.transform.Find ("PassengerText").GetComponent<Text> ();
		pass.text = speech;
        skip.transform.SetAsLastSibling();
        while (!forward)
			yield return null;
		Destroy (a);
		Destroy (b);
	}

	/// <summary>
	/// Handles the appearance and the disappearance of the passengers alternatively positioned speech bubble, bubble is visible until "Skip()" is triggered.
	/// </summary>
	/// <param name="speech">Text to enter in the bubble</param>
	IEnumerator PassAltBubble (String speech)
	{
		forward = false;
		GameObject a = Instantiate (bubble2);
		a.transform.SetParent (canvas.transform, false);
		a.transform.localPosition = b3pos;
		GameObject b = Instantiate (skipTitle);
		b.transform.SetParent (canvas.transform, false);
		b.transform.localPosition = skipTitlepos;
		pass = a.transform.Find ("PassengerText").GetComponent<Text> ();
		pass.text = speech;
        skip.transform.SetAsLastSibling();
        while (!forward)
			yield return null;
		Destroy (a);
		Destroy (b);
	}

	/// <summary>
	/// The contents of the first cutscene.
	/// </summary>
	IEnumerator PlayFirst ()
	{
		Debug.Log ("Playing first cutscene");
		PlayerController.PlayCutsceneAudio ();
		StartCoroutine (MainBubble ("Ah, what a beatiful day to be a taxi driver in Helsinki, Finland!"));
		while (!forward)
			yield return null;
		forward = false;
		GameObject passenger = Instantiate (passenger1);
		passenger.transform.localPosition = passenger1.transform.position;
		passenger.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		while (!Physics2D.OverlapCircle (passenger.GetComponent<Rigidbody2D> ().position, passenger.GetComponent<CircleCollider2D> ().radius, ground))
			yield return null;
		forward = false;
		StartCoroutine (PassBubble ("TAXI!"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (MainBubble ("A passenger! Where to?"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (PassBubble ("I need to get to Tampere ASAP!"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (MainBubble ("Tampere, eh? I smell money here...!"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (PassBubble ("Yes yes, let's go!"));
		while (!forward)
			yield return null;
		forward = false;
        
		passenger.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-8, 5);
		passenger.GetComponent<Rigidbody2D> ().angularVelocity = 1080;
		while (!Physics2D.OverlapCircle (passenger.GetComponent<Rigidbody2D> ().position, passenger.GetComponent<CircleCollider2D> ().radius, taxi))
			yield return null;
		forward = false;
		PlayerController.PlayLevelAudio ();
		LevelLoader.LoadLevel (LevelLoader.level1);

		LevelLoader.levelToLoad = LevelLoader.cutscene;
		i++;
		Destroy (passenger);
	}

	/// <summary>
	/// The contents of the second cutscene.
	/// </summary>
	IEnumerator PlaySecond ()
	{
		Debug.Log ("Playing second cutscene");
		PlayerController.PlayCutsceneAudio ();
		StartCoroutine (MainBubble ("Here we are!"));
		while (!forward)
			yield return null;
		forward = false;
		GameObject passenger = Instantiate (passenger1);
		passenger.transform.localPosition = new Vector2 (0, -29);
		passenger.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		passenger.GetComponent<Rigidbody2D> ().velocity = new Vector2 (9, 7);
		passenger.GetComponent<Rigidbody2D> ().angularVelocity = -1000;
		while (!Physics2D.OverlapCircle (passenger.GetComponent<Rigidbody2D> ().position, passenger.GetComponent<CircleCollider2D> ().radius, ground))
			yield return null;
		forward = false;
		passenger.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		StartCoroutine (PassBubble ("Damn you we're slow! It's like you did it on purpose!"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (MainBubble ("...the road was bumpy and stuff"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (PassBubble ("Yeah sure. Hmph."));
		while (!forward)
			yield return null;
		forward = false;
		passenger.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		passenger.GetComponent<Rigidbody2D> ().velocity = new Vector2 (9, 7);
		passenger.GetComponent<Rigidbody2D> ().angularVelocity = -1000;
		while (!forward)
			yield return null;
		forward = false;
		Destroy (passenger);
		StartCoroutine (MainBubble ("What an idiot, nothing but money matters anyway!"));
		while (!forward)
			yield return null;
		forward = false;
		passenger = Instantiate (passenger2);
		passenger.transform.localPosition = passenger2.transform.position;
		passenger.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		while (!Physics2D.OverlapCircle (passenger.GetComponent<Rigidbody2D> ().position, passenger.GetComponent<CircleCollider2D> ().radius, ground))
			yield return null;
		forward = false;
		StartCoroutine (MainBubble ("Oh! More money incoming!"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (PassBubble ("What?"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (MainBubble ("Uh, I mean, another new... person! Like, incoming!"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (PassBubble ("Rrrright... Can you take me to Lohja?"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (MainBubble ("Where is this Lohja?"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (PassBubble ("Do you know the rainforests in the south? That's Lohja."));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (MainBubble ("Whoa! Someone actually WANTS there?"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (PassBubble ("I'm probably out of my mind, but yes, I'd like to go there."));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (MainBubble ("Well, hop in and lets go!"));
		while (!forward)
			yield return null;
		forward = false;
		passenger.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-3, 4);
		passenger.GetComponent<Rigidbody2D> ().angularVelocity = 1080;
		while (!Physics2D.OverlapCircle (passenger.GetComponent<Rigidbody2D> ().position, passenger.GetComponent<CircleCollider2D> ().radius, taxi))
			yield return null;
		forward = false;
		PlayerController.PlayLevelAudio ();
		LevelLoader.LoadLevel (LevelLoader.level2);
		LevelLoader.levelToLoad = LevelLoader.cutscene;
		i++;
		Destroy (passenger);
	}

	/// <summary>
	/// The contents of the third cutscene.
	/// </summary>
	IEnumerator PlayThird ()
	{
		Debug.Log ("Playing third cutscene");
		PlayerController.PlayCutsceneAudio ();
		StartCoroutine (MainBubble ("So this is Lohja..."));
		while (!forward)
			yield return null;
		forward = false;
		GameObject passenger = Instantiate (passenger2);
		passenger.transform.localPosition = new Vector2 (0, -29);
		passenger.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		passenger.GetComponent<Rigidbody2D> ().velocity = new Vector2 (9, 7);
		passenger.GetComponent<Rigidbody2D> ().angularVelocity = -1000;
		while (!Physics2D.OverlapCircle (passenger.GetComponent<Rigidbody2D> ().position, passenger.GetComponent<CircleCollider2D> ().radius, ground))
			yield return null;
		forward = false;
		passenger.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		StartCoroutine (PassBubble ("I already regret wanting here!"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (MainBubble ("And the most important thing is that you paid to get here!"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (PassBubble ("OH GOD WHAT IS WRONG WITH ME !"));
		while (!forward)
			yield return null;
		forward = false;
		passenger.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		passenger.GetComponent<Rigidbody2D> ().velocity = new Vector2 (9, 7);
		passenger.GetComponent<Rigidbody2D> ().angularVelocity = -1000;
		while (!forward)
			yield return null;
		forward = false;
		Destroy (passenger);
		StartCoroutine (MainBubble ("Passengers please! I don't want to be here any longer!"));
		while (!forward)
			yield return null;
		forward = false;
		passenger = Instantiate (passenger3);
		passenger.transform.localPosition = passenger3.transform.position;
		passenger.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		while (!Physics2D.OverlapCircle (passenger.GetComponent<Rigidbody2D> ().position, passenger.GetComponent<CircleCollider2D> ().radius, ground))
			yield return null;
		forward = false;
		StartCoroutine (MainBubble ("Finally! Need a ride?"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (PassBubble ("Yes."));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (MainBubble ("Figured! Who would want to be here anyway! Where to?"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (PassBubble ("Turku."));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (MainBubble ("Turku? Can you be more specific? It's a big city."));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (PassBubble ("Harbour."));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (MainBubble ("Yeah sure, hop in and we'll be out of this hellhole!"));
		while (!forward)
			yield return null;
		forward = false;
		passenger.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-3, 4);
		passenger.GetComponent<Rigidbody2D> ().angularVelocity = 850;
		while (!Physics2D.OverlapCircle (passenger.GetComponent<Rigidbody2D> ().position, passenger.GetComponent<CircleCollider2D> ().radius, taxi))
			yield return null;
		forward = false;
		CameraController.externallyControlled = true;
		CameraController.ControlCamera (-0.54F, -30.2F, 0.3F);
		StartCoroutine (PassBubble ("Wait a second..."));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (PassBubble ("I know that face..."));
		while (!forward)
			yield return null;
		forward = false;
		PlayerController.PlayLevelAudio ();
		LevelLoader.LoadLevel (LevelLoader.level3);
		CameraController.externallyControlled = false;
		CameraController.ControlCamera (0, 0, 5);
		LevelLoader.levelToLoad = LevelLoader.cutscene;
		i++;
		Destroy (passenger);
	}

	/// <summary>
	/// The contents of the fourth cutscene.
	/// </summary>
	IEnumerator PlayFourth ()
	{
		Debug.Log ("Playing third cutscene");
		PlayerController.PlayCutsceneAudio ();
		GameObject boat = Instantiate (boaty);
		boat.transform.localPosition = new Vector3 (13.2F, -28.6F, 0);
		StartCoroutine (MainBubble ("Here we are! Harbour of Turku! Cash or credit card?"));
		while (!forward)
			yield return null;
		forward = false;
		GameObject passenger = Instantiate (passenger3);
		passenger.transform.localPosition = new Vector2 (0, -29);
		passenger.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		passenger.GetComponent<Rigidbody2D> ().velocity = new Vector2 (9, 8);
		passenger.GetComponent<Rigidbody2D> ().angularVelocity = -1000;
		while (!Physics2D.OverlapCircle (passenger.GetComponent<Rigidbody2D> ().position, passenger.GetComponent<CircleCollider2D> ().radius, ground))
			yield return null;
		forward = false;
		passenger.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		StartCoroutine (PassAltBubble ("HAHAHA"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (MainBubble ("Hey, you forgot to pay!"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (PassAltBubble ("I don't need to pay you anything!"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (MainBubble ("What!? How come!?"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (PassAltBubble ("Look."));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (MainBubble ("???"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (PassAltBubble ("I am your father!"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (MainBubble ("NOOOOOOOOOO!"));
		while (!forward)
			yield return null;
		forward = false;
		StartCoroutine (PassAltBubble ("See you again in another ten years!"));
		while (!forward)
			yield return null;
		forward = false;
		passenger.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		while (!Physics2D.OverlapCircle (passenger.GetComponent<Rigidbody2D> ().position, passenger.GetComponent<CircleCollider2D> ().radius, ground))
			yield return null;
		forward = false;
		while (boat.transform.position.x < 25) {
			boat.transform.Translate (0.01F, 0, 0);
			yield return null;
		}
        HudManager.GameOver();
        forward = false;
		SceneManager.LoadScene ("title");
	}

	/// <summary>
	/// The contents of the fifth (placeholder) cutscene.
	/// </summary>
	IEnumerator PlayFifth ()
	{
		throw new NotImplementedException ();
	}

	/// <summary>
	/// The contents of the sixth (placeholder) cutscene.
	/// </summary>
	IEnumerator PlaySixth ()
	{
		throw new NotImplementedException ();
	}

	/// <summary>
	/// The contents of the seventh (placeholder) cutscene.
	/// </summary>
	IEnumerator PlaySeventh ()
	{
		throw new NotImplementedException ();
	}

	/// <summary>
	/// The contents of the eighth (placeholder) cutscene.
	/// </summary>
	IEnumerator PlayEighth ()
	{
		throw new NotImplementedException ();
	}
}
