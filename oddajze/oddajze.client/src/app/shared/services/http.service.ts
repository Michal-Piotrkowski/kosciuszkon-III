import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { environment } from '../../../environment/environment';

@Injectable({
    providedIn: "root"
})

export class HttpService {
  get apiUrl(): string | undefined {
    return  environment.apiUrl;
  }

  constructor(private http: HttpClient) {}

  get(endpoint: string, options?: any): Observable<any> {
    return this.http.get(`${this.apiUrl}/${endpoint}`, options);
  }

  getSpecial(endpoint: string, options?: any): Observable<any> {
    return this.http.get(`${environment.apiUrlSpecial}${endpoint}`, options).pipe(
      catchError(error => {
        console.error('Error occurred:', error);
        return throwError('Something went wrong!');
      })
    );
  }

  post(endpoint: string, data: any, options?: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/${endpoint}`, data, options).pipe(
      catchError(error => {
        console.error('Error occurred:', error);
        return throwError('Something went wrong!');
      })
    );
  }

  postSpecial(endpoint: string, data: any, options?: any): Observable<any> {
    return this.http.post(`${environment.apiUrlSpecial}${endpoint}`, data, options).pipe(
      catchError(error => {
        console.error('Error occurred:', error);
        return throwError('Something went wrong!');
      })
    );
  }

  put(endpoint: string, data: any, options?: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${endpoint}`, data, options);
  }

  delete(endpoint: string, options?: any): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${endpoint}`, options);
  }
}