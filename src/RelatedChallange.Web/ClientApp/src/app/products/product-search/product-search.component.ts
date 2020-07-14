import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';

import { Observable } from 'rxjs';

import * as productActions from '../state/product.actions';
import * as fromProduct from '../state/product.reducer';
import { Product, SearchProduct } from '../product.model';

@Component({
  selector: 'app-product-search',
  templateUrl: './product-search.component.html',
  styleUrls: ['./product-search.component.css']
})
export class ProductSearchComponent implements OnInit {
  productForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private store: Store<fromProduct.AppState>
  ) { }
  selectedItems: any;

  ngOnInit() {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      tags: ['', Validators.required]
    });
  }

  searchProduct() {
    const searchProduct: SearchProduct = {
      name: this.productForm.get('name').value,
      tagNameList: this.productForm.get('tags').value
    };

    this.store.dispatch(new productActions.SearchProducts(searchProduct));
  }
}
