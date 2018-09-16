using CloudCanards.Util;
using UnityEngine;

public class Shield : MonoBehaviour
{
	Vector3 mouse_pos;
	public new Transform transform;
	Vector3 object_pos;
	float angle;
	public float reflectMeeter = 20f;
	float reflectMeeterMax;
	bool mouseClicked = false;

	[SerializeField]
	Sprite block;

	[SerializeField]
	Sprite down;

	[SerializeField]
	float rechargeRate = 1;

	[SerializeField]
	float depleateRate = 1;

	private Vector2 _prevMousePos;

	// Use this for initialization
	void Start()
	{
		reflectMeeterMax = reflectMeeter;
		_prevMousePos = Input.mousePosition;
	}

	// Update is called once per frame
	void Update()
	{
		float fire = Input.GetAxis("Fire1");
		if (fire > 0)
		{
			reflectMeeter -= (reflectMeeter <= 0) ? 0 : Time.deltaTime * depleateRate;
		}
		else
		{
			reflectMeeter += (reflectMeeter >= reflectMeeterMax) ? 0 : Time.deltaTime * rechargeRate;
		}

		GameObject child = gameObject.transform.GetChild(0).gameObject;
		if (reflectMeeter > 0f && fire > 0)
		{
			//child.transform.tag = "Reflective";
			child.GetComponent<BoxCollider2D>().enabled = true;
			child.GetComponent<SpriteRenderer>().sprite = block;
		}
		else
		{
			//child.transform.tag = "Untagged";
			child.GetComponent<BoxCollider2D>().enabled = false;
			child.GetComponent<SpriteRenderer>().sprite = down;
		}

		mouse_pos = Input.mousePosition;
		if ((Vector2) mouse_pos == _prevMousePos)
		{
			var joystick = new Vector2(Input.GetAxis("JoystickX"), Input.GetAxis("JoystickY"));
			if (joystick.sqrMagnitude > 0.01f)
			{
				angle = joystick.GetAngle() * Mathf.Rad2Deg;
				base.transform.rotation = Quaternion.Euler(0, 0, angle);
			}

			return;
		}
		mouse_pos.z = 0;
		object_pos = Camera.main.WorldToScreenPoint(base.transform.position);
		
		mouse_pos.x = mouse_pos.x - object_pos.x;
		mouse_pos.y = mouse_pos.y - object_pos.y;
		angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		base.transform.rotation = Quaternion.Euler(0, 0, angle);
	}
}