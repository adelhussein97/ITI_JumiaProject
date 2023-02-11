function ShowCartItems() {
	let cart = {};
	if (localStorage.getItem("cart")) {
		cart = JSON.parse(localStorage.getItem("cart"));
	}
	let tbody = document.getElementById("cart");
	var totalcart = document.getElementById("Totalcart");
	totalcart.innerHTML = "$ " + localStorage.getItem("sum");

	var countcart = document.getElementsByClassName("count-cart")[0];
	countcart.innerHTML = localStorage.Count;

	for (let id in cart) {
		let item = cart[id];
		let tr = document.createElement("tr");
		let image_td = document.createElement("td");

		let image = document.createElement("img");
		image.src = item.Image;
		image_td.appendChild(image);
		tr.appendChild(image_td);

		let title_td = document.createElement("td");
		title_td.textContent = item.prdName;
		tr.appendChild(title_td);

		let price_td = document.createElement("td");
		price_td.textContent = item.price;
		tr.appendChild(price_td);

		let input_td = document.createElement("td");
		let input = document.createElement("input");
		input.setAttribute("type", "number");
		input.addEventListener("change", function () {
			if (input.value < 0) {
				return false;
			}
			total_td.textContent = Number(input.value) * Number(item.price);
		});
		input.value = item.qty;
		input.style.width = "100px";
		input.style.height = "30px";
		input.style.textAlign = "center";

		input_td.appendChild(input);
		tr.appendChild(input_td);

		var total_td = document.createElement("td");
		total_td.textContent = Number(item.qty) * Number(item.price);

		tr.appendChild(total_td);

		let remove_td = document.createElement("td");
		remove_td.textContent = "X";
		remove_td.className = "remove_this";
		tr.appendChild(remove_td);
		tbody.appendChild(tr);
	}
}
