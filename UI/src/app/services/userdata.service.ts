import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../features/models';

@Injectable({
  providedIn: 'root'
})
export class UserdataService {
  private baseUrl="http://localhost:36228";
  // private baseUrl="https://3fc6-103-149-159-67.ngrok.io";

  constructor(private http: HttpClient) { }

  getUsers(){
    return this.http.get<User[]>(`${this.baseUrl}/api/v1/users`);
  }

  addUser(payload: any){
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    return this.http.post<User>(`${this.baseUrl}/api/v1/user`, JSON.stringify(payload), httpOptions);
  }

  updateUser(payload: any){
    return this.http.put(`${this.baseUrl}/api/v1/user`, payload);
  }
}
