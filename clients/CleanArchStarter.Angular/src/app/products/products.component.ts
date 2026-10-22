import { Component, inject, OnInit } from '@angular/core';
import { CurrencyPipe } from '@angular/common';
import { ProductService } from './product.service';
import { Product } from './product.model';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CurrencyPipe],
  template: `
    @if (loading) {
      <p class="status">Loading&#x2026;</p>
    } @else if (error) {
      <p class="error">{{ error }}</p>
    } @else {
      <table>
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Price</th>
          </tr>
        </thead>
        <tbody>
          @for (product of products; track product.id) {
            <tr>
              <td>{{ product.id }}</td>
              <td>{{ product.name }}</td>
              <td>{{ product.price | currency }}</td>
            </tr>
          }
        </tbody>
      </table>
    }
  `
})
export class ProductsComponent implements OnInit {
  private readonly productService = inject(ProductService);

  products: Product[] = [];
  loading = true;
  error = '';

  ngOnInit(): void {
    this.productService.getAll().subscribe({
      next: (products) => {
        this.products = products;
        this.loading = false;
      },
      error: () => {
        this.error = 'Failed to load products. Make sure the API is running on http://localhost:5015.';
        this.loading = false;
      }
    });
  }
}
