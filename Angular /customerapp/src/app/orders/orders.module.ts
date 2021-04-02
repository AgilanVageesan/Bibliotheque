import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderComponent } from './order/order.component';
import { Route, RouterModule } from '@angular/router';

const routes: Route[] = [
  {
    path:'',
    component: OrderComponent
  }
];

@NgModule({
  declarations: [OrderComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class OrdersModule { }
