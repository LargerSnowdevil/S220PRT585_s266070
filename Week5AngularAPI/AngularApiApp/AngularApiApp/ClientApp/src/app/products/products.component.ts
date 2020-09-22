import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductService } from '../services/product.service';
import { Product } from '../models/product';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  products$: Observable<Product[]>;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts() {
    this.products$ = this.productService.getAllProducts();
  }

  delete(productId) {
    const ans = confirm('Are you sure you want to delete Product: ' + productId + '?');

    if (ans) {
      this.productService.deleteProduct(productId).subscribe((data) => { this.loadProducts(); });
    }
  }
}
