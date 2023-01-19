let urlCoffee = "http://localhost:5283/api/Coffee/Allcoffee";
let urlIngridients = "http://localhost:5283/api/Ingridient/AllIngridient";
let urlISpecialCoffee =
  "http://localhost:5283/api/SpecialCoffee/AllSpecialCoffee";

let totalSum = 0;
let change = 0;
let ingridientInsert = 0;
const html = {
  coffeeList: document.getElementById("coffee"),
  spiner: document.getElementById("spiner"),
  special: document.getElementById("special"),
  standard: document.getElementById("standard"),
  container: document.getElementById("coffee"),
};
function spinerLoader(state) {
  if (state) {
    html.spiner.style.display = "block";
  } else {
    html.spiner.style.display = "none";
  }
}
function isCreatCard(state) {
  if (state) {
    html.coffeeList.style.display = "flex";
  } else {
    html.coffeeList.style.display = "none";
  }
}
function submitForm() {
  html.coffeeList.innerHTML = `<div id="success-message"><h1>Thank you for your order, have a nice day with the best coffee!<h1> <p>Take your change: ${change} MKD</p> <button class="exit" onclick="getAllCoffee()()">Exit</button></div>`;
}
function createSpecial(specialCoffee) {
  let card = `
    <div class="card">
    <img src="${specialCoffee.images}" alt="Coffee" />
    <div class="card-content">
    <h2 class="card-title">${specialCoffee.coffeeTypeName}</h2>
    <h3>Price: ${specialCoffee.price} MKD</h3>
    <button class="btn" id="${specialCoffee.id}" onclick="getPriceSpecialAndIngridients(${specialCoffee.id})">Buy <i class="fa fa-coffee"></i></button>
    </div>
  </div>`;
  return card;
}
function createCard(coffee) {
  let card = `
    <div class="card">
    <img src="${coffee.images}" alt="Coffee" />
    <div class="card-content">
    <h2 class="card-title">${coffee.coffeeTypeName}</h2>
    <h3>Price: ${coffee.price} MKD</h3>
    <button class="btn" id="${coffee.id}" onclick="getPriceAndIngridients(${coffee.id})">Buy <i class="fa fa-coffee"></i></button>
    </div>
  </div>`;
  return card;
}
function createIngridient(ingridient) {
  return `<div class="button-container"><button class="ingridients" onclick="sumIn(${ingridient.price})">${ingridient.name} - ${ingridient.price} MKD</button></div>`;
}

function ingridientSum(ingridient) {
  let ingridientSum = document.getElementById("ingridientSum");
  ingridientInsert = ingridientInsert + ingridient;
  ingridientSum.innerText = `Ingridient sum: ${ingridientInsert} MKD`;
}
function sumIn(ingridient) {
  let node = document.getElementById("totalPrice");
  totalSum = totalSum + ingridient;
  node.innerText = `Total price: ${totalSum} MKD`;
  ingridientSum(ingridient)
}

function getChange() {
  let enteredAmount = document.getElementById("money").value;
  let nodeChange = document.getElementById("resultChange");
  change = enteredAmount - totalSum;

  if (change >= 0) {
    submitForm();
  } else {
    nodeChange.innerText = `You don't have enough money`;
    nodeChange.style.display = "block";
    nodeChange.style.color = "red";
  }
}

function getAllCoffee() {
  spinerLoader(true);
  fetch(urlCoffee)
    .then((data) => data.json())
    .then(function (result) {
      spinerLoader(false);
      isCreatCard(true);
      html.special.style.display = "block";
      html.standard.style.display = "none";
      html.container.style.width = "50%";
      try {
        html.coffeeList.innerHTML = "";
        totalSum = 0;
        ingridientInsert = 0;
        for (let coffee of result) {
          html.coffeeList.innerHTML += createCard(coffee);
        }
      } catch (error) {
        html.coffeeList.innerHTML = `
      <div>
          Please try again!
      </div>`;
      }
    });
}

function getAllSpecialCoffee() {
  spinerLoader(true);
  fetch(urlISpecialCoffee)
    .then((data) => data.json())
    .then(function (result) {
      spinerLoader(false);
      isCreatCard(true);
      html.special.style.display = "none";
      html.standard.style.display = "block";
      html.container.style.width = "50%";
      try {
        html.coffeeList.innerHTML = "";
        for (let coffee of result) {
          html.coffeeList.innerHTML += createSpecial(coffee);
        }
      } catch (error) {
        html.coffeeList.innerHTML = `
      <div>
          Please try again!
      </div>`;
      }
    });
}

function getAllIngridient() {
  spinerLoader(true);
  fetch(urlIngridients)
    .then((data) => data.json())
    .then(function (result) {
      spinerLoader(false);
      try {
        for (let ingridient of result) {
          html.coffeeList.innerHTML += createIngridient(ingridient);
        }
      } catch (error) {
        html.coffeeList.innerHTML = `
        <div>
        Please try again!
        </div>`;
      }
    });
}

function Order(coffee) {
  totalSum = totalSum + coffee.price;
  let card = `
  <div class="order" id="orderTrue">
        <ul class="price" id="order">
          <li class="header">${coffee.coffeeTypeName}</li>
          <li class="grey">Price: ${coffee.price} MKD</li>
          <li class="grey" id="ingridientSum">Ingridient sum: ${ingridientInsert} MKD</li>
          <li class="grey" id="totalPrice">Total price: ${totalSum} MKD</li>
          <li class="grey"><label for="money">Enter money: </label><br><input type="number" name="money" id="money"  placeholder="Enter money"></li>
          <li class="grey" id="resultChange">Take your change: ${change} MKD</li>
          <li class="grey"><a href="#" class="button" onclick="getChange()">Buy</a> <a href="#" class="button" onclick="getAllCoffee()">Cancel</a></li> 
        </ul>
  </div>`;

  return card;
}

function getPriceAndIngridients(coffeeId) {
  let urlCoffee = `http://localhost:5283/api/Coffee/${coffeeId}`;

  fetch(urlCoffee)
    .then((data) => data.json())
    .then(function (coffee) {
      html.special.style.display = "none";
      html.standard.style.display = "none";
      html.container.style.width = "60%";
      html.coffeeList.innerHTML = "";
      html.coffeeList.innerHTML = Order(coffee);
      getAllIngridient();
    });
}
function getPriceSpecialAndIngridients(coffeeId) {
  let urlCoffee = `http://localhost:5283/api/SpecialCoffee/${coffeeId}`;

  fetch(urlCoffee)
    .then((data) => data.json())
    .then(function (coffee) {
      html.special.style.display = "none";
      html.standard.style.display = "none";
      html.container.style.width = "60%";
      html.coffeeList.innerHTML = "";
      html.coffeeList.innerHTML = Order(coffee);
      getAllIngridient();
    });
}

html.special.addEventListener("click", getAllSpecialCoffee);
html.standard.addEventListener("click", getAllCoffee);
getAllCoffee();
