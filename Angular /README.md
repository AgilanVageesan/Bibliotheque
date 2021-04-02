# JavaScript and Angular Training

--------------------------------------------------------------

Softwares Required:
1) Visual Studio Code.
2) Chrome Web Browser
3) NodeJS Latest LTS
------------------------------------


JavaScript:
	==> Scripting language, loosely typed, interpreted language

	ECMAScript ==> 5 version 
	ES2015
	ESNext


	var x = "Smith";

	x = 24;

	x = true;
==================================================

first.js

//
	c is global scope
	b is function scope.
	JS engine doesn't understand block scope
//

var g = 100;

function doTask() {
	var a = 10;
	if( g > a) {
		var b = 20;
		c  = 50;
	}

	console.log(g, a, b, c);
}

doTask()
console.log(g, a, b, c);

============================================================


second.js

function add(x,y) {
	return x + y;
}

console.log(add(4,5)); // 9

--------------
semi-colon insertion [ AST ]

function add(x,y) {
	return 
		x + y;
}

console.log(add(4,5)); // undefined

return;
x + y; // unreachable
======

function doTask() {
	
}

x = doTask(); // value of x is undefined
---------------------------------------------------------

Object Oriented Programming with JS
-----------------------------------

1) var obj = new Object();

	// add state

	obj.name = "Peter";
	obj.age = 26;

	// add behaviour

	obj.getInfo = function() {
		return this.name + this. age;
	}


var add = new Function("x","y", "return x + y");
var one = add;

add(2,4); // 6
one(5,6); // perfect
-------------------------------------------------------

2) Function constructors

	function Person(name, age) {
		this.name = name;
		this.age = age;
	}


	var p1 = new Person("Raj",45);
	var p2 = new Person("Smitha", 24);

	Person("Tim", 24);

	// Adding object owned instance methods

	function Person(name, age) {
		this.name = name;
		this.age = age;
		this.getName = function() {
			return this.name;
		}
		this.getAge = function() {
			return this.age;
		}
	}

	var p1 = new Person("Raj",45);
	var p2 = new Person("Smitha", 24);

	=================
Addy Osmani

// Adding class owned instance methods

	function Person(name, age) {
		this.name = name;
		this.age = age;
	}

	Person.prototype.getName = function() {
			return this.name;
	}
	
	Person.prototype.getAge = function() {
			return this.age;
	}

	var p1 = new Person("Raj",45);
	var p2 = new Person("Smitha", 24);
===============
 
 3) JSON ==> JavaScript Object Notation ==> Singleton object
 	==> Prefer JSON: if only state is there; or state + behaviour for singleton

 	var obj = {};

 	var person = {
 		"name" : "Peter",
 		"age": 26,
 		"getName": function() {
 			return this.name;
 		}
 	};

 	var product = {
 		"name" : "iPhone 12",
 		"price": 98000.00
 	};

 	var products = [{"name": "IPhone"}, {"name": "Sony Bravia"}];

 	======
 	JSON ==> carriers of data
 ------------------------

 var person = {
 		"name" : "Peter",
 		"age": 26,
 		"getName": function() {
 			return this.name;
 		},
 		"getAge" : function() {
 			return this.age;
 		}
 	};

 	var product = {
 		"name" : "iPhone 12",
 		"price": 98000.00
 	};


person.getName(); // Peter

var ref = person.getName; // reference is obtained but context is not copied; has global context

ref(); // "" ==> got the name of "window"

var ref2 = person.getName.bind(person);
-------------------------------------------------

 var person = {
 		"name" : "Peter",
 		"age": 26,
 		"getName": function() {
 			return this.name;
 		},
 		"getAge" : function() {
 			return this.age;
 		}
 	};

 	var product = {
 		"name" : "iPhone 12",
 		"price": 98000.00
 	};


 function update(name) {
 	this.name = name;
}

update.call(person,"Jack");
update.call(product, "Oppo");

-----------------

method.invoke(obj,args);
-----------------------------------------------


class Person {
	public void test() {

	}
}

Person p = new Person();
p.test(); // ==> test(p); ==> first argument is implicit this
----------------------------------------------------------------------------------

Functional Style of Programming
-------------------------------
	High Order Functions: functions which accept function as arguments; functions which return a function
	==> treat function as first class members ==> similar to primitive or object

	var data = [45,26,722,782,221];

	for(var i = 0; i < data.length; i++) {
		console.log(data[i]);
	}

	for(var i = 0; i < data.length; i++) {
		alert(data[i]);
	}


	for(var i = 0; i < data.length; i++) {
		sendResponse(data[i]);
	}
===========
	var data = [45,26,722,782,221];
	var names = ["Brad", "Angelina", "George","Lee"];
	// HOF
	function forEach(elems, action) {
		for(var i = 0; i < elems.length; i++) {
			action(elems[i]);
		}
	}

	forEach(data, console.log);
	forEach(data, alert);
	forEach(names, console.log);
==============================================
HOF's: map, filter, reduce, forEach, limit, skip, flatMap

OOP ==> Methods Tightly copuled to state of object

Account ==> deposit(); withdraw() ==> methods are tightly coupled to "balance" state
Functional style of programming ==> functionality which can be used on any type 
===============================================================

Lambda experssion ==> JRE ==> can treat this lamda as function [ HOF] or it can treat this 
as short cut for Objects of anonymous class
=======================================================

HOF ==> function return a function
// pure function
function greeting(msg, name) {
	return msg + " " + name;
}

greeting("Good morning", "Smith");
greeting("Good morning", "Sam");
greeting("Good morning", "Zaheer");
greeting("Good morning", "Sita");
===================================================

HOF
function greeting(msg) {
	return function(name) {
		return msg + " " + name;
	}
}

var morningGreet = greeting("Good morning"); 
// closure ==> returned function can
// access members of outer function
// morningGreet can access "msg" which is a part of closure

console.log(morningGreet("Geetha"));
console.log(morningGreet("Rita"));

var greet = greeting("Good Day");
console.log(greet("Geetha"));
==================================================


getProduct(10); 
	==> Make a REST call 
	==> hit the db and return the value

.....

getProduct(10);
	==> i expect data to come from cache
	==> don't make REST api calls
==================================================




memGetProduct(getProduct);
// memGetProduct has different closure [ Cache is differnet from memFib]

memGetProduct(10);

memGetProduct(10);
======================================
HOF, closure
Memoize Design Pattern ==> implementing cache
===================================================

Module pattern; Memoize; Observable; Factory; Singleton
========================================================
JS ==> Event loop; callback; stack

first.js

console.log("Hello");

setInterval(function time() {
	console.log("Time out");
}, 100);

console.log("Good Day !!!");

$("#add").click(function clicked() {
	console.log("You Clicked!!!");
});

console.log("Bye!!!");
==========================================
Event loop psuedocode:

myFile.js

var pendingTimers = [];
var pendingOSTasks = [];
var pendingOperations = [];  

myFile.runContents();

function shouldContinue() {
	checks the arrays
}

while(shouldContinue()) {
	 // check pendingTimer
	 // check pendingTasks
	 // check pending operations
	 // check setImmediate
	 // handle close events
}
=====================================================

ES2015 ==> ES 6

ES 6 or ESNext ===> TransCompiler ==> lower version [ ES 5]

Transpiler ==> Babel; Tracuer

Babel is a free and open-source JavaScript transcompiler that is mainly used to convert ECMAScript 2015+ code into a backwards compatible version of JavaScript that can be run by older JavaScript engines.
=====================================================

ES 6 Features:

1) block level scope [ let and const]

var g = 100;

function doTask() {
	var a = 10;
	if( g > a) {
		let b = 20;
		const PI = 3.14159;
		c  = 50;
	}

	console.log(g, a, b, c); // b, PI is not visible
}

doTask()
console.log(g, a, b, c);  // a, b, PI is not visible
==========================================================

2) Default value and arrow operators
Prior to ES 6
function add(x, y) {
	var result = 0;
	x = x || 0;
	y = y || 0;
	result = x + y;
	return result;
}

add(4,5); // 9
add(4); // x is 4 and y is 0
add(); // x and y are 0

---
ES 6+
function add(x = 0, y = 0) {
	var result = 0;
 	result = x + y;
 	return result;
}
add(4,5); // 9
add(4); // x is 4 and y is 0
add(); // x and y are 0
----------

let sub = (x = 0, y = 0) => x - y;
-------------------------------------------------

3) New String literal 
	`Hello` 

	ES 5 had two ways to declare a string
	'test'
	"world"

	------------

	var name = "Roger";

	var elem = `
		<div>
			Welcome ${name},
			Angular Training
			SocGen
		</div>
	`;

	----------
	Old Way:
	elem = "<div> Welcome" + name + "<br/> Angular Training <br />";
--------------------------------
4) Promise API
  	make a promise call ==> that can resolve or reject

  	Synchronous:
  	function doTask() {

  	}

  	let res = doTask();

  	console.log("Got result ", res); // blocked
  	--------

  	ASynchronous which is promise based:
  	function doTask() {

  	}

  	doTask().then(
  		(data) => console.log(data), /* resolve code */
  		(err) => console.log(err) /* reject code */
  	);

  	console.log("Got result "); // not blocked


	fetch('https://jsonplaceholder.typicode.com/users')
		.then( res => res.json())
		.then(data => console.log(data))
		.catch(err => console.log(err));


=====
npm i axios
	axios.get(url, callback);
=============================================
5) Async and await to simplify Promise based API and avoid lots of callback

	function someTask() {
		firstTask().then( data => secondTask(data) {

			}. then(thirdTask(data) {

				}))
	}
===================

6) class

class Person {
	constructor(name = "", age = 0) {
		this.name = name;
		this.age = age;
	}

	getName() {
		return this.name;
	}
}


let p = new Person("Tim",13);
let p1  = new Person();
let p2 = new Person("Rajesh");

this code is converted to function constructor and using prototype to add methods

class Product{
	constuctor(name,price) {
		...
	}
}

class Mobile extends Product {
	constructor(name,price,connectivity) {
		super(name,price);
		this.connectivity = connectivity;
    }
}
==================================================

7) ES 6 Module system

	Pure vanilla module system:
	// IIFE
	(function Product() {
		var name; // private to Product
	 	function getName() {
	 		// name is visbile
		}

		function getInfo() {
			// name is visbile
		}
	})();


	(function Payment() {
		var mode; // private to Payment
		function checkout() {
			// mode
		}
	})();

	=========

	CommonJS module system, AMD, ES 6 module system
	========================
	ES 6 module system; each file is a module

	lib.js

	export function add() {}

	export function sub() {}

	export default function multiply() { }
	function util() {}


	other.js

	import multiply, {add,sub} from './lib';

	add();
	sub();
	multiply();
========================================================
8) Generators

function* task() {
	console.log("one");
	yield 100;
	console.log("two");
	console.log("three");
	yield "test";
	console.log("four");
	yield "completed!!!"
}

let iter = task();

iter.next();

iter.next();

iter.next();
===============================================
9) Destructuring array and objects

var colors = ["red","green","blue","pink"];

old way:
var r = colors[0];
var g = colors [1];

ES6 way:

var [r,g,...others] = colors;
------------

 var product = { "id": 1, "name": "iPhone", "price": 124447.44, "category": "mobile" };

 var {name, price} = product;
----------------
10) cloning

var data = [67,2,522,41];

var ref = data;

ref[0] = 88;
---------------
clone:
var ref = [...data];
ref[0] = 88;

var product = { "id": 1, "name": "iPhone", "price": 124447.44, "category": "mobile" };
var ref = product; // reference
var p = {...product} // p is a clone and not direct refernce to product
============

self read: Proxy, Reflection
=======================================================================

Node.JS
	==> Environment with V8 JS engine + libuv C++ apis
	==> mediator between JS code ==> C++

	APIs
	environment to build web appilication
	-------------

	common things need for building web application:
	1) transpile [ ES6 or ESNext ==> ES5]
	2) minify and uglify code
	3) run tests [ unit testing or E2E]
	4) bundle
		n no of css files
		n no of js files ==> bundle.js

		<script src="a.js"></script>
		<script src="b.js"></script>
		<script src="c.js"></script>
		<script src="d.js"></script>
============================================================

package.json ===> maven
 ==> a file to have info about prod-dependendenies and development devlopment-dep
 track of modules used in project
 ==> script==> run, compile, bundle, test, lint

 NPM ==> Node Package Manager
 	manage dependencies
 
 // testing dependencies
 "devDependencies": {
    "chai": "^4.3.0",
    "mocha": "^8.3.0",
    "request": "^2.88.2"
  }

  "chai": "4.3.0"; ==> exact version

  "chai": "~4.3.0"; ==> major version has to be 4; minor version anything

   "chai": "^4.3.0"; ==> any version equal or greater than 4.3
===============================================================

Day 2:
-------

var data = [4,5,7,3,11];

function addElem(elem) {
	var newArray = [...data, elem];
	return newArray;
}
-------------------------------------------

Recap: JS [ call stack, event loop and callbacks, engines, creation stage and execution stage]
OOP, functional style of programming, ES 2015 features

Node.Js [ JS ==> Node.JS ==> V8 [ js engine] and libuv [ C++ librarires]]
==> APIs ==> Prefer node.JS for real time streaming of data, Asynchronous exection
	==> Don;t use Node js for CPU intense operations
==> for developing client side application [ not running]
	==> Test, Linting [ static code analyis], Browserify [Babel, TSC for transpile], Minify, Uglify
-----------

Node.JS application
	==> package.json [ all dependencies required for production + development]
		npm i [ install]
		depdencies will be downloaded into node_modules folder

		Node Package Manager
		
		npm i -D chai mocha request [ Development dependency]

		npm i bootstrap [ production dependency]
-------------------------------------
		CommonJS Module system [ module.exports and require]

		node.js + Express.Js [ Spring boot similar API] ==> Dashboard updates
--------------------------------------------------------------------------------

Testing Node JS applications
	Unit Testing librarires for JS : Jasmine, Mocha, Jest
	chai ==> assertion library [ Jasmine comes built in with assertion library]
==================================================================================

TypeScript ==> introduces types
	[string, number, boolean, enum, any, ..]

	TypeScript ==> tsc ==> JS 
===================================================
npm i -g typescript

let name:string = "Smith";

name = 13; // error

let flag:boolean = true;

flag = 1; // error
------------------------

interface Person {
	name:string;
	age?:number
}

function addPerson(person:Person) {
	//
}

addPerson({"name":"tim", "age": 35});

addPerson({"firstName":"tim", "age": 35}); // error

addPerson({})// error

addPerson({"name":"tim" }); // valid


DART/ TypeScript/ CoffeScript are used only in development ==> JS
----------------------------------------------------------------------

JavaScript development tools to automate tasks
	transpile, test, linting, minify, uglyfy, broswerfy

	Grunt, Gulp, parcel and Webpack
	Grunt is a JavaScript task runner, a tool used to automatically perform frequent tasks such as minification, compilation, unit testing, and linting


	let data : any;
==========
Decorators: ==> Metadata

@NgModule({
	
})
export class MyModule {
	
}

Decorators can be placed on type [ class, interface], fields and methods

export class Person {

	@Upper()
	firstName:string;
}
------------------------------------

Angular 

npm i -g @angular/cli@latest
----------------------------

ng --version

=======================

Angular is a framework for buidling web application [ client side]

Server Side Rendering: converts state to representation [ HTML] and sent to client
	1) JSP, themyleaf, Servlet
	2) ASP, ASP.NET
	3) PHP
	4) EJS, JADE , PUG

Client Side Rendering:
	Data [ JSON / XML] is sent to client, client renders it to represention
	Template Librariries : jQuery, Underscore, Mustache, HandleBars, Knokout

	React == > View Library

	CanJS, Backbone and Angular are Frameworks
================================================================================

Angular Building blocks:
	1) Modules
		CustomerModule, TripModule, PaymentModule, DriverManagementModule
		==> Modularization
		Minumu in Angular is it's a one module [ AppModule]

		Modules group Components, directives, services, Interceptors, Pipe, Guard, router

	2) Component
		a) is a class with state and behaviour
		b) has a selector
		c) template
		d) style

		@Component{
			selector: 'app-customer',
			templateUrl : 'customer.html'
		}
		class CustomerComponent {
				state and behviour
		}
		in HTML page: <app-customer></app-cusomter>

	3) service
		==> business logic
		==> Any Http calls to REST APi

		@Injectable()
		class DataService {

		}

		==> Supports Dependency Injection [ IOC]
	4) Directives
		==> used along with HTML elements or Angular Components

		<app-component appHover></app-component>

		appHover is a directive ==> Provide additional functionality to the component/HTML

	5) Router
		Each URI should display different View in Single Page Application

		index.html

		http://sony.com

		Routers:

		http://sony.com/tv
		http://sony.com/products
		http://sony.com/locations

		http://amazon.com/mobile/iPhone12

		http://amazon.com/mobile/pixel2

		Why we need Routers?
			==> SEO
			==> Bookmark
			==> Navigation between views and not pages [ History API]
			==> Security to few URIs
	6) Pipe [ filter of Angular.js]
		==> transform data

		class UpperPipe {

		}
		
		{{firstName | upper}}
======================

ng new customerapp
yes to strict
No to Routing
CSS
==========================

customerapp$ code .

Angular can be JIT [ Compiler is required in Browser],

AOT ==> A Head of Time [ Compiler not required in Browser]

==========

To start angular app:
ng serve
or
npm start
ng serve --port 4401 
===========================


Resume @ 2:00
==================

main.ts ==> bootstrap ==> AppModule ==> loads all components, directives, services,...
and bootstraps AppComponent

AppComponet selector was <app-root></app-root> was used in index.html

app.component.html {{title}}

class AppComponent {
	title:string = "Welcome to Angular!!!";
}

=============
ng g c customers

generate component customers
===================
ng g interface common/customer
===================

Structural Directive: *ngFor


Structural directives can create / remove DOM elements dynamically
==================================
	AppComponent ==> CustomersComponent ==> CustomerCardComponent
										==> CustomerListComponent



customer.component.html
<app-customercard [customers]="customers"></app-customercard>

mechanism to pass on data from parent to child 
property []

@Input()
customers:Customer[];
=======================================================

1) main.ts
	==> bootstraps AppModule
2) AppModule
	bootStraps AppComponent

3) AppComponent
	app.component.html
		<app-customers></app-customers>

4) CustomerComponent
		class CustoemrCopment {
			customers:Customer[] ;;;
		}
		
		customers.component.html
			<app-customerscard [customers]="customers"></app-customerscard>

5) CustomersCardComponent
		class CustomersCardComponent {

			@Input()
			customers:Customer[];
	}
==================
Events:
()
=====

Parent ==> Child ==> @Input() [ data is passed]

Child ==> Parent ==> @Output() [ thro EventEmitter ==> events]
=======================

FormsModule should be added to app.module.ts to use form controls like "text"

FoermsModule is required to use [(ngModel)]
 <input
                      type="text"
                      name="searchText"
                      [(ngModel)] = "searchText"
                      (keyup) = "filterCustomers()"
                      class="novalidate form-control  mr-sm-2"
                />

      [(ngModel)] = "searchText" is for 2 way data binding

      Component <---> Form
===============================================

@Input() parent to child
@Output() child event propagate to Parent

[] binding properties
() binding events
[(ngModel)] 2 way binding

*ngFor is structural directive
=========================================================
 

Testing
	Unit Testing
		JEST, Jasmine, Mocha
		Angular cli by default adds Jasmin and Karma for Unit testing
		Karma ==> test Runner
	E2E Testing
		protractor 
		selenium
		cypress
=======================================================
unit testing:
 npm test
============================
Service ==> rxjs
Router; Guard
ViewChild; ChangeDetectionStrategy
Pipe; Interceptor
===========

Day 3:
======

Module, Component [ selector, templateUrl, stlyeUrl, state and behaviour (specfic to component)]

Built-in Structural Directives [ *ngFor and *ngIf] of Angular


Bootstrap for RWD and font-awesome.
====================================================

@Input() mechansim using which parent passes data to child
@Output() way to propagate events to parent [ using EventEmitter]

FormsModule has [(ngModel)] is for 2-way binding [ forms control and state of component]

() for handling events
[] for properties
[()] for 2 way binding
-----------------------------------------------------------------

Directives:
 used along with Component
 
 Component will have state and behviour assoicated with Model data [ product, customer, order]

 Why Directives?
 	==> adding behaviour which is independent of Model data
 	==> example: take a cursor on component; it should highlight; add border; visbile/hide
 	==> No tempate or styles of its own
 ng g directive common/appHover



@Directive({
  selector: '[appHover]'
})
export class AppHoverDirective {

  constructor() { }

}

<div appHover></div>

(click) = "doTask()"



===========

Adding Module:
ng g module orders

Adding a component to orders module:
ng g c orders/order
=============================
SPA we need different views for different URLs

Adding Routers to our application:

	http://localhost:4200/customers
	Customer view

	http://localhost:4200/customers/edit/3
	open customer edit form

	http://localhost:4200/orders

	Order View

	http://localhost:4200/

	Home page
========================


	http://localhost:4200/order will use OrdersModule
	within orders module we can many routes [ Child routes]
	
	http://localhost:4200/order/report

	http://localhost:4200/order/customer/3

	http://localhost:4200/order/

	Lazy Loading:
	{
    path: 'order',
    loadChildren: () => import('./orders/orders.module').then(m => m.OrdersModule)
  }
===========================================================

 Adding Guard to protect routes:
 ng g guard test
================================================================

@ViewChild and @ViewChildren

ViewChild can be used directly on DOM or component
https://angular-ivy-x4w54z.stackblitz.io

Angular TemplateRef ==> #name
==============================================

rxjs ==> Reactive JS based on Observable and Observer pattern

benefit over promise API:

Promise can send a single return ==> resolved output or rejected [ single output]

Generators ==> Multiple return values [ pull]

Observable ==> emits series of data [ push ]
=======

we can cancel the subscription
we can implement debounce
====================================================

rxjs/opertors ==> map, filter, reduce, flatMap, limit, skip, debounceTime

import { fromEvent } from "rxjs";

import { debounceTime } from "rxjs/operators";

let clicks = fromEvent(document, "click");

let result = clicks.pipe(debounceTime(1000));

result.subscribe(x => console.log(x));
result.subscribe(x => console.log("clicked!!!"));

===========================

https://rxjs-pipeexample.stackblitz.io

=============================================
Fr
Angular Service:
	==> Add a behaviour common to many component
	==> Communicate between components which are not parent-child
		Parent-child: ==> @Output(), @Input(), @ViewChild(), @viewChildren()
	==> use services to make REST calls
=========================

app.module.ts

"providers": [SharedService]
=============================
Subject ==> a type of Observable with multicast

import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
	 providedIn: 'root'
})
export class SharedService {
  data: any[] = [];
  subject: Subject<any> = new Subject();
  constructor() { }

  getSubject(): Subject<any> {
    return this.subject;
  }

  addData(elem) {
    this.data.push(elem);
    this.subject.next(this.data);
  }
}
=============

export class AppComponent {
  constructor(private sharedService: SharedService) {}

  ngOnInit(): void {
    setInterval(() => {
      this.sharedService.addData(new Date());
    }, 2000);
  }
}
==============

export class HelloComponent {
  information: any[] = [];
  constructor(private sharedService: SharedService) {}

  ngOnInit(): void {
    this.sharedService.getSubject().subscribe(data => {
      this.information = data;
    });
  }
}
=======================================
ng g service common/data

Services and REST calls
1) Build REST Apis
	json-server to build REST aPis
	==> makes use of "json" file for REST endpoint



=============================================
HttpClientModule ==> gives HttpClient service using which we can make APi calls based on Observable

ChangeDetectionStrategy:
https://change.stackblitz.io

import {
  Component,
  Input,
  ChangeDetectionStrategy,
  ChangeDetectorRef
} from "@angular/core";

@Component({
  selector: "app-child",
  templateUrl: "./child.component.html",
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ChildComponent {
  @Input() data: string[];

  constructor(private cd: ChangeDetectorRef) {}

  refresh() {
    this.cd.detectChanges();
  }
}


 
export class AppComponent {
  foods = ["Burger", "Rolls", "Pizza"];

  addFood(food) {
   // this.foods = [...this.foods, food];
    this.foods.push(food);
  }
}
<input #newFood type="text" placeholder="Enter a new food">
<button (click)="addFood(newFood.value)">Add food</button>

<app-child [data]="foods"></app-child>

Child:
@Component({
  selector: "app-child",
  templateUrl: "./child.component.html" 
})
export class ChildComponent {
  @Input() data: string[];
}
<ul>
  <li *ngFor="let item of data">{{ item }}</li>
</ul>
============

ChangeDetectionStrategy.Default
child gets updated whenever a new data is injected; doesn't get updated if passed data gets new value
========================================================================

RTL ==> React Testing Library ==> Jest
Cypress, Enzyme

ATB ==> Jasmine and Karma
==============================================

angular university
https://angular-university.io/
