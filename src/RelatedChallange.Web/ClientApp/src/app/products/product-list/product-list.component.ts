import { Observable, of } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import * as productActions from '../state/product.actions';
import * as fromProduct from '../state/product.reducer';
import { Product, Tag } from '../product.model';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products$: Observable<Product[]>;
  error$: Observable<string>;

  constructor(private store: Store<any>) { }

  ngOnInit() {
    this.store.dispatch(new productActions.LoadProducts());
    this.products$ = this.store.pipe(select(fromProduct.getProducts));
    this.error$ = this.store.pipe(select(fromProduct.getError));
  }

  deleteProduct(product: Product) {
    if (confirm('Are You Sure want to Delete the User?')) {
      this.store.dispatch(new productActions.DeleteProduct(product.id));
    }
  }

  editProduct(product: Product) {
    console.log(this.store);

    this.store.dispatch(new productActions.LoadProduct(product.id));
  }
}
