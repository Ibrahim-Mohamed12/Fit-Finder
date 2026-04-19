const openBtn = document.getElementById("openAddCard");
const closeBtn = document.getElementById("closeAddCard");
const modal = document.getElementById("addCardModal");

openBtn.addEventListener("click", () => {
    modal.classList.remove("hidden");
    modal.classList.add("flex");
});

closeBtn.addEventListener("click", () => {
    modal.classList.add("hidden");
    modal.classList.remove("flex");
});

window.addEventListener("click", (e) => {
    if (e.target === modal) {
        modal.classList.add("hidden");
        modal.classList.remove("flex");
    }
});