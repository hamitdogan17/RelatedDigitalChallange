import { ProductEffect } from './state/product.effects';
import { StoreModule } from '@ngrx/store';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './product/product.component';
import { ProductAddComponent } from './product-add/product-add.component';
import { ProductEditComponent } from './product-edit/product-edit.component';
import { ProductListComponent } from './product-list/product-list.component';
import { productReducer } from './state/product.reducer';
import { EffectsModule, Actions } from '@ngrx/effects';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { TagInputModule } from 'ngx-chips';
import { ProductSearchComponent } from './product-search/product-search.component';

const productRoutes: Routes = [{ path: '', component: ProductComponent }];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(productRoutes),
    StoreModule.forFeature('products', productReducer),
    EffectsModule.forFeature([ProductEffect]),
    ReactiveFormsModule,
    FormsModule,
    TagInputModule,
  ],
  declarations: [ProductComponent, ProductAddComponent, ProductEditComponent, ProductListComponent, ProductSearchComponent]
})
export class ProductsModule { }
