var fs = require('fs'); // CommonJS module system

let content = fs.readFileSync("nodefirst.js");  //blocked mode

console.log(content.toString());