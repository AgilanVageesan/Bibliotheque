console.log("Hello");
setImmediate(function imd() {
    console.log("imd fn")
});

setInterval(function time() {
    console.log("Time out");
}, 0);

console.log("Good Day !!!");

// document.addEventListener("click", function clicked() {
//     console.log("You Clicked!!!");
// });


console.log("Bye!!!");