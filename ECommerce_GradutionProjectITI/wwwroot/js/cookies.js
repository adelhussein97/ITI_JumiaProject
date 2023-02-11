var input1 = document.getElementById( "input_1" );
var input2 = document.getElementById( "input_2" );
var input3 = document.getElementById( "input_3" );
var txtarea_1 = document.getElementById( "textarea_1" );
var regex1 = /[a-zA-Z]{3,15}$/; //name
var regex3 = /^(01)(0|1|2|5)[0-9]{8}$/; // phone
var regex4 = /^[a-zA-Z]{3,20}[0-9]+[$ & #]*(@)(gmail|yahoo|outlook|hotmail)(.com)$/i   // email
function validateform ( ev )
{
	if (
		regex1.test( input1.value ) &&
		regex3.test( input3.value ) &&
		regex4.test( input2.value )
	)
	{
		var d = new Date();
		d.setMonth( d.getMonth() + 2 );

		document.cookie = "userName= " + input1.value + ";expires = " + d;
		document.cookie = "userEmail= " + input2.value + ";expires = " + d;
		document.cookie = "userPhone= " + input3.value + ";expires = " + d;
		document.cookie = "textarea = " + txtarea_1.value + ";expires = " + d;
		input2.value = "";
		input3.value = "";
		input1.value = "";
		txtarea_1.value = "";
	} else
	{
		ev.preventDefault();
	}
}

function username ()
{
	var name2 = input1.value;
	if ( regex1.test( name2 ) )
	{
		document.getElementById( "fspan1" ).textContent = "";
	} else
	{
		document.getElementById( "fspan1" ).style.color = "red";
		document.getElementById( "fspan1" ).textContent = "Invalid Name !";
	}
}
function userphone ()
{
	var phone = input3.value;
	if ( regex3.test( phone ) )
	{
		document.getElementById( "fspan3" ).textContent = "";
	} else
	{
		document.getElementById( "fspan3" ).style.color = "red";
		document.getElementById( "fspan3" ).textContent = "Invalid phone number !";
	}
}
function userEmail ()
{
	var email = input2.value;
	if ( regex4.test( email ) )
	{
		document.getElementById( "fspan2" ).textContent = "";
	} else
	{
		document.getElementById( "fspan2" ).style.color = "red";
		document.getElementById( "fspan2" ).textContent = "Invalid Email !";
	}
}
