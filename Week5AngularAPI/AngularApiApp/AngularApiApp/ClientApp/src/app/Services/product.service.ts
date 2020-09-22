import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  appUrl: string;
  appApi: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  }

  constructor(private http: HttpClient) {
    this.appUrl = environment.appUrl;
    this.appApi = 'api/Products/'
  }

  getAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.appUrl + this.appApi)
    .pipe(retry(1), catchError(this.errorHandler));
  }

  getProduct(productId: number): Observable<Product> {
    return this.http.get<Product>(this.appUrl + this.appApi + productId)
    .pipe(retry(1), catchError(this.errorHandler));
  }

  saveProduct(product): Observable<Product> {
    return this.http.post<Product>(this.appUrl + this.appApi, JSON.stringify(product), this.httpOptions)
    .pipe(retry(1), catchError(this.errorHandler));
  }

  updateProduct(productId: number, product): Observable<Product> {
    return this.http.put<Product>(this.appUrl + this.appApi + productId, JSON.stringify(product), this.httpOptions)
    .pipe(retry(1), catchError(this.errorHandler));
  }

  deleteProduct(productId: number): Observable<Product> {
    return this.http.delete<Product>(this.appUrl + this.appApi + productId)
    .pipe(retry(1), catchError(this.errorHandler));
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
