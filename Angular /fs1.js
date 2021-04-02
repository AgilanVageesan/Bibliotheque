var fs = require('fs');

fs.readFile("fs1.js", (err, data) => {
console.log(data.toString());
});

console.log("done!!"); // not blocked