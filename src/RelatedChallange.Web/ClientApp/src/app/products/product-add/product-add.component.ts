import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import * as productActions from '../state/product.actions';
import * as fromProduct from '../state/product.reducer';
import { Product } from '../product.model';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  productForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private store: Store<fromProduct.AppState>
  ) { }
  selectedItems: any;
  ngOnInit() {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      unitPrice: ['', Validators.required],
      unitsInStock: ['', Validators.required],
      tags: [[], Validators.required]
    });
  }

  createProduct() {
    const newProduct: Product = {
      tags: this.productForm.get('tags').value,
      name: this.productForm.get('name').value,
      unitPrice: this.productForm.get('unitPrice').value
    };

    this.store.dispatch(new productActions.CreateProduct(newProduct));

    this.productForm.reset();
  }
}
