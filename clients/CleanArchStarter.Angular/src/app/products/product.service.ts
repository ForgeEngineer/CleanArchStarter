import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Product } from './product.model';

@Injectable({ providedIn: 'root' })
export class ProductService {
  private readonly http = inject(HttpClient);

  getAll(): Observable<Product[]> {
    return this.http.get<Product[]>(`${environment.apiBaseUrl}/api/products`);
  }
}
