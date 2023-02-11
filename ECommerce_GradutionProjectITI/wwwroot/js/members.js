// start members
let members_imgs = document.querySelectorAll(".members img");
let information = document.querySelectorAll(".information");

for (let i = 0; i <= members_imgs.length; i++) {
	members_imgs[i].onclick = function () {
		information.forEach((e) => {
			e.style.transform = "translateY(100%)";
			e.onclick = function () {
				e.style.transform = "translateY(100%)";
			};
		});
		information[i].style.transform = "translateY(-100%)";
	};
}

// end members
// data manipolation
let sign_text = document.getElementById("icon");
if (localStorage.userName) {
	sign_text.textContent = localStorage.userName;
}
sign_text.onclick = function () {
	window.open("login.html", "_self");
};
//data manipolation
var selectcart = document.getElementsByClassName("cart");
selectcart[0].onclick = function () {
	window.open("cart.html", "_self");
};
