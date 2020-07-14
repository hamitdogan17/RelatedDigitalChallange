import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Product, Tag, SearchProduct } from './product.model';

@Injectable({
    providedIn: 'root'
})
export class ProductService {
  private productsUrl;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.productsUrl = baseUrl + "api/v1/Product";
  }

    getProducts(): Observable<Product[]> {
        return this.http.get<Product[]>(this.productsUrl);
    }

    getProductById(payload: number): Observable<Product> {
        const reqBody = { id: payload };

        return this.http.post<Product>(this.productsUrl + '/GetProductById', reqBody);
    }

    createProduct(payload: Product): Observable<Product> {
        const reqBody = { product: payload };
        const config = { headers: new HttpHeaders().set('Content-Type', 'application/json') };
        return this.http.post<Product>(this.productsUrl + '/CreateProduct', reqBody, config);
    }

    updateProduct(product: Product): Observable<Product> {
        const reqBody = { product: product };
        console.log(reqBody);
        const config = { headers: new HttpHeaders().set('Content-Type', 'application/json') };
        return this.http.post<Product>(this.productsUrl + '/UpdateProduct', reqBody, config);
    }

    deleteProduct(payload: number) {
        const reqBody = { id: payload };

        return this.http.post<Product>(this.productsUrl + '/DeleteProductById', reqBody);
    }

    searchProducts(payload: SearchProduct): Observable<Product[]> {
          if (payload.tagNameList !== undefined && payload.tagNameList.length > 0 && payload.name) {
              const reqBody = { name: payload.name, tagNameList: payload.tagNameList };
              return this.http.post<Product[]>(this.productsUrl + '/GetProductsByNameAndTagNames', reqBody);
          } else if (payload.tagNameList !== undefined  && payload.tagNameList.length > 0) {
              const reqBody = { tagNameList: payload.tagNameList };
              return this.http.post<Product[]>(this.productsUrl + '/GetProductsByTagNames', reqBody);
          } else if (payload.name) {
              const reqBody = { name: payload.name };
              return this.http.post<Product[]>(this.productsUrl + '/GetProductsByName', reqBody);
          } else {
              return this.http.get<Product[]>(this.productsUrl);
          }
      }
}
