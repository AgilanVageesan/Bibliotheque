import { Component, OnInit } from '@angular/core';
import { Customer } from '../common/customer';
import { DataService } from '../common/data.service';

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

  constructor(private dataService: DataService) {
  }

  ngOnInit(): void {
   this.dataService.getCustomers().subscribe(data => {
      this.customers = this.original = data;
   });
  }

  deleteCustomer(id:number):void {
    this.customers = this.customers.filter(c => c.id !== id);
    this.dataService.deleteCustomer(id).subscribe(() => console.log("deleted!!!"));
  }

  filterCustomers() {
    this.customers = this.original.filter(c => {
      return c.firstName.toUpperCase().indexOf(this.searchText.toUpperCase()) >= 0 ||
      c.lastName.toUpperCase().indexOf(this.searchText.toUpperCase()) >=0 
    });
  }
 }
