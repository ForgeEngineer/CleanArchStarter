import { Component } from '@angular/core';
import { ProductsComponent } from './products/products.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ProductsComponent],
  template: `
    <h1>Products</h1>
    <app-products />
  `
})
export class AppComponent {}
