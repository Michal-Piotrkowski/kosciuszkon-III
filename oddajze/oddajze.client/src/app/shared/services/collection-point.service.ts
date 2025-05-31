import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CollectionPoint } from '../models/collection-point.model';

@Injectable({
  providedIn: 'root'
})
export class CollectionPointService {
  private apiUrl = 'http://localhost:5041/api/CollectionPoints';

  constructor(private http: HttpClient) { }

  getAllPoints(): Observable<CollectionPoint[]> {
    return this.http.get<CollectionPoint[]>(`${this.apiUrl}/all`);
  }
}
