function validateForm() {
    const employeeId = document.getElementById("text").value;

    // Check if empId field is empty
    if (employeeId === "") {
        alert("Please enter EMPLOYEE_ID.");
        return false;
    }

    // Check if empId field contains only numbers
    if (!/^\d{5}$/.test(employeeId)) {
        alert("Enter a valid EMPLOYEE_ID (only 5 digits number).");
        return false;
    }

    return true;
}

const form = document.querySelector("form");
form.addEventListener("submit", function (event) {
    event.preventDefault(); // prevent form submission if validation fails
    if (validateForm()) {
        // submit form if validation passes
        alert("Submitted successfully.");
        // add code to submit form here
    }
});