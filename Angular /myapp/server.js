var http = require('http'); // import using commonJs module
var compute = require('./compute');
var url = require('url');

// http://localhost:3000/add?x=20&y=15
// http://localhost:3000/sub?x=20&y=5

var server = http.createServer( (req,res) => {
    var pathname = url.parse(req.url).pathname; // /add or /sub
    var query = url.parse(req.url,true).query
    if(pathname === '/add') {
        res.write(compute.add(parseInt(query["x"]),parseInt(query["y"])).toString());
    } else if (pathname === '/sub') {
        res.write(compute.sub(parseInt(query["x"]),parseInt(query["y"])).toString());
    }
    res.end();
});

server.listen(3000, () => console.log("server started!!!"));
