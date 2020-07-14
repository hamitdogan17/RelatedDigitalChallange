import { DecimalPipe } from '@angular/common';

export interface Product {
    id?: number;
    name: string;
    unitPrice: number;
    tags: [Tag];
}

export interface Tag {
    id?: number;
    name: string;
}

export interface SearchProduct {
  name: string;
  tagNameList: [string];
}
