import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';

import { AppComponent } from './app.component';
import { CustomersComponent } from './customers/customers.component';
import { CustomercardComponent } from './customercard/customercard.component';
import { CustomerlistComponent } from './customerlist/customerlist.component';
import { AppHoverDirective } from './common/app-hover.directive';
import { HomeComponent } from './home/home.component';
import { Route, RouterModule } from '@angular/router';
import { TestGuard } from './test.guard';
import { CustomerEditComponent } from './customers/customer-edit.component';
import { TextconverterPipe } from './textconverter.pipe';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { MyhttpInterceptor } from './myhttp.interceptor';

const routes: Route[] = [
  {
    path: 'customers',
    component: CustomersComponent
  },
  {
    path: 'customers/edit/:id',
    component: CustomerEditComponent
  },
  {
    path: 'order',
    canActivate: [TestGuard],
    loadChildren: () => import('./orders/orders.module').then(m => m.OrdersModule)
  },
  {
    path:'home',
    component: HomeComponent
  },
  {
    path :'',
    component: HomeComponent
  },
  {
    path :'**',
    component: HomeComponent
  },
  
]

@NgModule({
  declarations: [
    AppComponent,
    CustomersComponent,
    CustomercardComponent,
    CustomerlistComponent,
    CustomerEditComponent,
    AppHoverDirective,
    HomeComponent,
    TextconverterPipe
  ],
  imports: [
    BrowserModule, HttpClientModule, FormsModule, RouterModule.forRoot(routes)
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: MyhttpInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
