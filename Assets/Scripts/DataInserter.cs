using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataInserter : MonoBehaviour {

	// Public Variables
	public InputField inputFName				= null;

	public InputField inputLName				= null;

	public InputField inputUserName				= null;

	public InputField inputPassword				= null;

	public InputField inputConfirmPassword		= null;

	public InputField inputEmail				= null;

	public InputField inputConfirmEmail			= null;

	public InputField inputCompany				= null;

	public InputField inputCountry				= null;

	public Button Submit						= null;


	// Private Variables
	private string Base_URL						= "http://localhost/my_vie/";


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.SubmitUserInfo();
		}

	}

    #region Sign Up
    public void SubmitUserInfo()
	{
		this.Submit.interactable = false;
		// Validation
		if (!this.ValidateUserInfo()) return;

		this.CreateUser(
			this.inputFName.text,				// First Name
			this.inputLName.text,				// Last Name
			this.inputUserName.text,			// User Name
			this.inputPassword.text,			// User Password
			this.inputConfirmPassword.text,		// Confirm Password
			this.inputEmail.text,				// User E-mail
			this.inputConfirmEmail.text,		// Confirm E-mail
			this.inputCompany.text,				// Company Name (optional)
			this.inputCountry.text              // Country (optional)
		);
	}

	private void CreateUser(string first_name, string last_name, string username, string password, string confirm_password, string email, string confirm_email, string company, string country)
	{
		string URI = this.Base_URL + "createUser";

		WWWForm form = new WWWForm();
		form.AddField("first_name",			first_name);
		form.AddField("last_name",			last_name);
		form.AddField("username",			username);
		form.AddField("password",			password);
		form.AddField("confirm_password",	confirm_password);
		form.AddField("email",				email);
		form.AddField("confirm_email",		confirm_email);
		form.AddField("company",			company);
		form.AddField("country",			country);

		
		Web._instance.Post_Request(URI, form);
	}

	private bool ValidateUserInfo()
	{
		// Validate User input fields. It will be added later.
		return true;
	}

    #endregion

    public void Click_Btn_back()
	{
		Debug.Log("Clicked back button!");
	}
}
