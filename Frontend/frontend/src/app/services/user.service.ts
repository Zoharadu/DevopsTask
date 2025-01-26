import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserModel } from '../UserModel';

@Injectable({
  providedIn: 'root'
})

export class UserService {
  private apiUrl = 'https://localhost:7228/api';

  constructor(private http: HttpClient) {}

  addUser(user: any): Observable<any> {
    return this.http.post<UserModel>(`${this.apiUrl}/createUser`, user);
  }

  getUsers(): Observable<any[]> {
    return this.http.get<UserModel[]>(`${this.apiUrl}/readAllUser?`);
  }

  getUser(id: string): Observable<any[]> {
    return this.http.get<UserModel[]>(`${this.apiUrl}/readUser?id=${id}`);
  }

  updateUser(user: UserModel): Observable<any> {
    return this.http.patch<any>(`${this.apiUrl}/UpdateUser`, user, { responseType: 'text' as 'json' });
  }
  
  deleteUser(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/deleteUser?id=${id}`, { responseType: 'text' as 'json' });
  }
}
