import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  appUrl: string;
  appApi: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  }

  constructor(private http: HttpClient) {
    this.appUrl = environment.appUrl;
    this.appApi = 'api/Categories/'
  }

  getAllCategorys(): Observable<Category[]> {
    return this.http.get<Category[]>(this.appUrl + this.appApi)
    .pipe(retry(1), catchError(this.errorHandler));
  }

  getCategory(categoryId: number): Observable<Category> {
    return this.http.get<Category>(this.appUrl + this.appApi + categoryId)
    .pipe(retry(1), catchError(this.errorHandler));
  }

  saveCategory(category): Observable<Category> {
    return this.http.post<Category>(this.appUrl + this.appApi, JSON.stringify(category), this.httpOptions)
    .pipe(retry(1), catchError(this.errorHandler));
  }

  updateCategory(categoryId: number, category): Observable<Category> {
    return this.http.put<Category>(this.appUrl + this.appApi + categoryId, JSON.stringify(category), this.httpOptions)
    .pipe(retry(1), catchError(this.errorHandler));
  }

  deleteCategory(categoryId: number): Observable<Category> {
    return this.http.delete<Category>(this.appUrl + this.appApi + categoryId)
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
