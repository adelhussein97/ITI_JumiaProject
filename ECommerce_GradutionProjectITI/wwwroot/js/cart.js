let cart = {};

if (localStorage.getItem("cart")) {
	cart = JSON.parse(localStorage.getItem("cart"));
}
let btns = document.querySelectorAll("#add-to-cart-localstorage");

for (let i = 0; i < btns.length; i++) {
	let btn = btns[i];
	btn.addEventListener("click", add);
}

function add(event) {
	let id = event.target.dataset.id;
	let title = event.target.dataset.prdname;
	let price = Number(event.target.dataset.price);
	let prdImage = event.target.dataset.prdimage;
	//  If choose specific qty

	let _qty = document.getElementById("input-qtyCart");

	if (id in cart) {
		cart[id].prdQty++;
	} else {
		if (qty.value > 1) {
			let cartItem = {
				prdName: title,
				price: price,
				qty: _qty.value,
				Image: prdImage,
			};
		} else {
			let cartItem = {
				prdName: title,
				price: price,
				qty: 1,
				Image: prdImage,
			};
		}

		cart[id] = cartItem;
	}

	localStorage.setItem("cart", JSON.stringify(cart));
	updateCart();
}

function updateCart() {
	let Count = 0;
	let sum = 0;

	for (var item in cart) {
		sum += cart[item].price;
		Count++;
	}
	localStorage.setItem("sum", sum);
	localStorage.setItem("Count", Count);
	document.getElementsByClassName(
		"count-cart"
	)[0].textContent = localStorage.getItem("Count");
}

// Add Single Product Deatils to Local Storage

function addSingleProduct(event) {
	let prdName = event.target.dataset.prdname;
	let price = Number(event.target.dataset.price);
	let prdImage = event.target.dataset.prdimage;
	let ID = event.target.dataset.id;

	localStorage.setItem("prdName", prdName);
	localStorage.setItem("price", price);
	localStorage.setItem("prdImage", prdImage);
	localStorage.setItem("ID", ID);
}

// Get Product Details when Open any Product

function LoadPrdDetails() {
	var title = document.getElementById("product-title");
	var price = document.getElementById("prd-price");
	var imagesrc = document.getElementById("prd-image");

	title.innerHTML = localStorage.getItem("prdName");
	price.innerHTML = "$ " + localStorage.getItem("price");
	imagesrc.src = localStorage.getItem("prdImage");
	updateCart();
}

function AddTocartFromSingleProduct() {
	let id = localStorage.getItem("ID");
	let title = localStorage.getItem("prdName");
	let price = Number(localStorage.getItem("price"));
	let prdImage = localStorage.getItem("prdImage");

	if (id in cart) {
		cart[id].prdQty++;
	} else {
		let cartItem = {
			prdName: title,
			price: price,
			qty: 1,
			Image: prdImage,
		};
		cart[id] = cartItem;
	}

	localStorage.setItem("cart", JSON.stringify(cart));
	updateCart();
}

// Validate input qty number only
function ValidateQty(_event) {
	var keyCode = _event.keyCode; // backspace =8
	const codes = [96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 8];
	if (!codes.includes(keyCode)) {
		_event.preventDefault();
		return false;
	}
	return true;
}

// data manipolation
let sign_text = document.getElementById("icon");
if (localStorage.userName) {
	sign_text.textContent = localStorage.userName;
}
sign_text.onclick = function () {
	window.open("login.html", "_self");
};
//data manipolation

// start rate
let Persons = document.getElementsByClassName("review");
let day = 8;

fetch("https://reqres.in/api/users")
	.then((response) => response.json())
	.then((data) => {
		for (let i = 0; i < 4; i++) {
			let person = document.createElement("div");
			person.className = "person";
			let imgs = document.createElement("img");
			imgs.src = data.data[i].avatar;
			person.appendChild(imgs);
			let dataaa = document.createElement("div");
			dataaa.classList = "data";
			let time = document.createElement("p");
			time.className = "time";
			time.textContent = `${day} days`;
			day -= 2;
			dataaa.appendChild(time);
			let name = document.createElement("div");
			name.classList = "name";
			name.textContent = data.data[i].first_name;
			dataaa.appendChild(name);

			let report = document.createElement("p");
			report.classList = "report";
			report.textContent = "report";
			dataaa.appendChild(report);
			person.appendChild(dataaa);
			Persons[i].prepend(person);
		}
	});

// end rate
var selectcart = document.getElementsByClassName("cart");
selectcart[0].onclick = function () {
	window.open("cart.html", "_self");
};
//
