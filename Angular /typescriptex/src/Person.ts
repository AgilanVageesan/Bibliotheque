import {Course} from './Course';

@Course({
    "name" : "Angular v8"
})
export class Person {
    private name:string;
    constructor(name:string, private age:number) {
        this.name = name;
    }

    getName(): string {
        return this.name;
    }
    //property
    getDetails() : string {
        return this.name +", " + this.age;
    }
}