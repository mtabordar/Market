import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';
import 'rxjs/add/operator/switchMap';

import { Product } from '../shared/product';

import { ProductService } from '../shared/product.service';

@Component({
  selector: 'product',
  template: require('./product.component.html'),
})

export class ProductComponent implements OnInit {
  product: Product;
  errorMessage: string;
  productId: number;
  message: string;
  private sub: any;

  constructor(private productService: ProductService
    , private route: ActivatedRoute
    , private location: Location) {
    this.product = new Product;
  }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.productId = +params['id'];
      if (this.productId) {
        this.getProducts();
      }
    },
      error => console.log(error));
  }

  getProducts(): void {
    this.productService.getProduct(this.productId)
      .subscribe(
      product => this.product = product,
      error => this.errorMessage = <any>error);
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    this.productService.updateProduct(this.product)
      .subscribe(message => this.message = message,
      error => this.errorMessage = <any>error);
  }
}