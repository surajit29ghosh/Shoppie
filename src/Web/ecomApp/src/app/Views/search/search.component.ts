import { Component, OnInit } from '@angular/core';

import { CartService } from '../../services/cart.service';
import { ProductService } from '../../services/product.service';

import { CartDomain } from '../../domain/cart.domain';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  products: any[];

  constructor(private cart: CartService, private productService: ProductService, private cartService: CartService) { }

  ngOnInit(): void {
    this.productService.getAllProducts()
        .subscribe(data => this.products = data);
  }

  addToCart(product: any) {
    let newItem = new CartDomain();

    newItem.Id = product.id;
    newItem.ProductName = product.productName;

    this.cartService.addToCart(newItem);
    
    return false;
  }

}
