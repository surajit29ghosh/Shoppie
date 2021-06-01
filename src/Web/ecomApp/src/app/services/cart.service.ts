import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

import {CartDomain } from '../domain/cart.domain';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private cartCount = new Subject<number>();
  private items: number = 0;
  cart: CartDomain[] = [];

  getCartCount(): Observable<number> {
    return this.cartCount.asObservable();
  }

  constructor() {
   }

  addToCart(c:CartDomain) {
    this.items += 1;
    this.cartCount.next(this.items);
    
    this.cart.push(c);
  }
}
