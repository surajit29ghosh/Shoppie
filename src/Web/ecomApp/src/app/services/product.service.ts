import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private productApiURL: string = '/api/product/';

  constructor(private http: HttpClient) 
  { 

  }

  getAllProducts(): Observable<any[]> {
    return this.http.get<any[]>(environment.apiBaseURL + this.productApiURL + 'all');
  }

  searchProduct(q: string) {
    return this.http.get(environment.apiBaseURL + this.productApiURL + 'search/' + q);
  }
}
