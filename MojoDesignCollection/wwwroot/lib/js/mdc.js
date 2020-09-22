function openNav() {
    document.getElementById("side-shop").style.width = "15%";
    document.getElementById("open").style.right = "14%";
    var cartSummary = document.getElementById("cart-summary");
    cartSummary.style.transition = "width 2s";
    cartSummary.classList.add("cart-collapse");
   
}
function closeNav() {
    document.getElementById("side-shop").style.width = "0";
    document.getElementById("open").style.right = "0.7%";
    document.getElementById("cart-summary").classList.remove("cart-collapse");
}