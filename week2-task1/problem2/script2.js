function validateName() {
    const name = document.getElementById("name").value;
    const msg = document.getElementById("nameMsg");

    if (name.trim() === "") {
        msg.textContent = "Name cannot be empty";
        msg.style.color = "red";
    } else {
        msg.textContent = "Valid Name";
        msg.style.color = "green";
    }
}

function validateEmail() {
    const email = document.getElementById("email").value;
    const msg = document.getElementById("emailMsg");

    if (!email.includes("@")) {
        msg.textContent = "Email must contain @";
        msg.style.color = "red";
    } else {
        msg.textContent = "Valid Email";
        msg.style.color = "green";
    }
}

function validateAge() {
    const age = document.getElementById("age").value;
    const msg = document.getElementById("ageMsg");

    if (age <= 18) {
        msg.textContent = "Age must be greater than 18";
        msg.style.color = "red";
    } else {
        msg.textContent = "Valid Age";
        msg.style.color = "green";
    }
}

function saveData() {
    const name = document.getElementById("name").value;
    const email = document.getElementById("email").value;
    const age = document.getElementById("age").value;
    const finalMsg = document.getElementById("finalMsg");

    if (
        name.trim() !== "" &&
        email.includes("@") &&
        age > 18
    ) {
        sessionStorage.setItem("name", name);
        sessionStorage.setItem("email", email);
        sessionStorage.setItem("age", age);

        finalMsg.textContent = "Data Saved Successfully!";
        finalMsg.style.color = "green";
    } else {
        finalMsg.textContent = "Please fix errors before submitting.";
        finalMsg.style.color = "red";
    }
}