
interface Person {
	name:string;
	age?:number
}

function addPerson(person:Person) {
	console.log(person.name, person.age);
}

addPerson({"name":"tim", "age": 35});

addPerson({"name": "Yanni"});