import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Contact } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  baseApiUrl = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  getContacts(): Observable<Contact[]> {
    return this.http.get<Contact[]>(this.baseApiUrl + '/contacts');
  }

  getContact(id: number): Observable<Contact> {
    return this.http.get<Contact>(this.baseApiUrl + '/contacts/' + id);
  }
}
