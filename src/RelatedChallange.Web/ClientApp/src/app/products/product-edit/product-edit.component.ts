import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';

import { Observable } from 'rxjs';

import * as productActions from '../state/product.actions';
import * as fromProduct from '../state/product.reducer';
import { Product } from '../product.model';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
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
      id: null,
      tags: ['', Validators.required]
    });

    const product$: Observable<Product> = this.store.select(
      fromProduct.getCurrentProduct
    );

    product$.subscribe(currentProduct => {
      if (currentProduct) {
        this.productForm.patchValue({
          name: currentProduct.name,
          unitPrice: currentProduct.unitPrice,
          id: currentProduct.id,
          tags: currentProduct.tags
        });
      }
    });
  }

  updateProduct() {
    const updatedProduct: Product = {
      tags: this.productForm.get('tags').value,
      name: this.productForm.get('name').value,
      unitPrice: this.productForm.get('unitPrice').value,
      id: this.productForm.get('id').value
    };

    this.store.dispatch(new productActions.UpdateProduct(updatedProduct));
    this.productForm.reset();
  }
}
