document.addEventListener("DOMContentLoaded", () => {
    const rows = document.querySelectorAll(".bill_row"); //reference to each bill in table

    rows.forEach(row => {
        row.addEventListener("click", () => {
            const billId = row.getAttribute("data-billid"); //get data from clicked bill

            window.location.href = "/home/edit/" + billId; //explicitly pass billId to url/route
        })
    })
})