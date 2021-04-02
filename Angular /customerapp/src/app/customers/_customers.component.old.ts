import { Component, OnInit } from '@angular/core';
import { Customer } from '../common/customer';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  customers: Customer[] = [];
  original:Customer[] = [];
  searchText:string  = "";
  isCard:boolean = true;

  constructor() {
    this.customers = [{
      "id": 1,
      "firstName": "Rachel",
      "lastName": "Green ",
      "gender": "female",
      "address": "Blore"
    },
    {
      "id": 2,
      "firstName": "Chandler",
      "lastName": "Bing",
      "gender": "male",
      "address": "West Street"
    },
    {
      "id": 3,
      "firstName": "Joey",
      "lastName": "Tribbiani",
      "gender": "male",
      "address": "Kattegat"
    },
    {
      "id": 4,
      "firstName": "Monica",
      "lastName": "Geller",
      "gender": "female",
      "address": "some address"
    },
    {
      "id": 5,
      "firstName": "Ross",
      "lastName": "Geller",
      "gender": "male",
      "address": "some address "
    },
    {
      "id": 6,
      "firstName": "Phoebe",
      "lastName": "Buffay",
      "gender": "female",
      "address": "some address"
    }
    ];

    this.original = this.customers;
   }

  ngOnInit(): void {
   
  }

  deleteCustomer(id:number):void {
    this.customers = this.customers.filter(c => c.id !== id);
  }

  filterCustomers() {
    this.customers = this.original.filter(c => {
      return c.firstName.toUpperCase().indexOf(this.searchText.toUpperCase()) >= 0 ||
      c.lastName.toUpperCase().indexOf(this.searchText.toUpperCase()) >=0 
    });
  }
 }
