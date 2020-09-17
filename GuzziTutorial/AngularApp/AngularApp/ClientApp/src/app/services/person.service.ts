import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Person } from '../models/person';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  myAppUrl: string;
  myApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(private http: HttpClient) {
    this.myAppUrl = environment.appUrl;
    this.myApiUrl = 'api/People/';
  }

  getPeople(): Observable<Person[]> {
    return this.http.get<Person[]>(this.myAppUrl + this.myApiUrl)
    .pipe(retry(1), catchError(this.errorHandler));
  }

  getPerson(personId: number): Observable<Person> {
    return this.http.get<Person>(this.myAppUrl + this.myApiUrl + personId)
    .pipe(retry(1), catchError(this.errorHandler));
  }

  savePerson(person): Observable<Person> {
    return this.http.post<Person>(this.myAppUrl + this.myApiUrl, JSON.stringify(person), this.httpOptions)
    .pipe(retry(1), catchError(this.errorHandler));
  }

  updatePerson(personId: number, person): Observable<Person> {
    return this.http.put<Person>(this.myAppUrl + this.myApiUrl + personId, JSON.stringify(person), this.httpOptions)
    .pipe(retry(1), catchError(this.errorHandler));
  }

  deletePerson(personId: number): Observable<Person> {
    return this.http.delete<Person>(this.myAppUrl + this.myApiUrl + personId)
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

