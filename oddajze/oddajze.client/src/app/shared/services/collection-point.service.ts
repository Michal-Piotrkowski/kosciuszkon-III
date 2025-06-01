import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CollectionPoint } from '../models/collection-point.model';
import {HttpService} from "./http.service";
import {environment} from "../../../environment/environment";

@Injectable({
  providedIn: 'root'
})
export class CollectionPointService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpService) { }

  getAllPoints(): Observable<CollectionPoint[]> {
    return this.http.get('CollectionPoints/all');
  }
}
