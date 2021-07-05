using UnityEngine;
using System.Collections;

public class DataLoader : MonoBehaviour {

	public string[] userInfo;

	IEnumerator Start(){
		WWW UsersData = new WWW("http://localhost/my_vie/UsersData.php");
		yield return UsersData;
		string UsersDataString = UsersData.text;
		print (UsersDataString);
		userInfo = UsersDataString.Split(';');
		print(GetDataValue(userInfo[0], "First Name:"));
	}

	string GetDataValue(string data, string index){
		string value = data.Substring(data.IndexOf(index)+index.Length);
		if(value.Contains("|"))value = value.Remove(value.IndexOf("|"));
		return value;
	}


}


























//void Start(){
//	string data = "ID:1|Name:Health Potion|Type:consumables|Cost:50";
//	print(GetDataValue(data, "Cost:"));
//}
//
//void Update(){
//	
//}
//
//string GetDataValue(string data ,string index){
//	string value = data.Substring(data.IndexOf(index)+index.Length);
//	if(value.Contains("|"))value = value.Remove(value.IndexOf("|"));
//	return value;
//}
