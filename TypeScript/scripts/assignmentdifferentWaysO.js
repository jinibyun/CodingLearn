var d = new Object();
var a = Object.create(null);
var b = {};

var Obj = function(name) {
    this.name = name
  }
  var c = new Obj("hello"); 



function f(){};

new f(a, b, c);



// Create a new instance using f's prototype.
var newInstance = Object.create(f.prototype)
var result;

// Call the function
result = f.call(newInstance, a, b, c),

result && typeof result === 'object' ? result : newInstance;

function myObj(){};
myObj.prototype.name = "hello";
var k = new myObj();

class myObject  {
    constructor(name) {
      this.name = name;
    }
  }
  var e = new myObject("hello");
