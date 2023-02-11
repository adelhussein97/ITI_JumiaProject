let click_sign = document.getElementById("in");
let click_Register = document.getElementById("up");

let sign_in = document.getElementById("one");
let sign_up = document.getElementById("two");

click_sign.onclick = function () {
	click_sign.style.borderBottom = "5px solid gray";
	click_Register.style.borderBottom = "none";
	sign_up.style.transform = `translateX(0%)`;
	sign_in.style.transform = `translateX(100%)`;
};

click_Register.onclick = function () {
	click_sign.style.borderBottom = "none";
	click_Register.style.borderBottom = "5px solid gray";
	sign_in.style.transform = `translateX(0%)`;
	sign_up.style.transform = `translateX(-100%)`;
};
//data manipolation
let form_sign_up = document.getElementById("sn");
let sign_up_all_span = document.querySelectorAll("#sn span");
form_sign_up.addEventListener("submit", function (e) {
	localStorage.clear();
	if (form_sign_up[0].value.length < 5) {
		e.preventDefault();
		sign_up_all_span[0].style.display = "block";
	} else {
		sign_up_all_span[0].style.display = "none";
		localStorage.userName = form_sign_up[0].value;
	}
	if (form_sign_up[2].value.length > 6) {
		sign_up_all_span[1].style.display = "none";
		localStorage.password = form_sign_up[2].value;
	} else {
		e.preventDefault();
		sign_up_all_span[1].style.display = "block";
	}

	localStorage.email = form_sign_up[1].value;
});
let form_log_in = document.getElementById("snn");
let log_in_all_span = document.querySelectorAll("#snn span");
form_log_in.addEventListener("submit", function (e) {
	if (form_log_in[0].value != localStorage.email) {
		log_in_all_span[0].style.display = "block";
		log_in_all_span[1].style.display = "none";
		e.preventDefault();
	} else {
		if (form_log_in[1].value != localStorage.password) {
			e.preventDefault();
			log_in_all_span[0].style.display = "none";
			log_in_all_span[1].style.display = "block";
		}
	}
});
