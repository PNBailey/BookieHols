import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { RegisterUser } from '../Models/registerUser';
import { User } from '../Models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl: string = "https://localhost:7161/api/Account"
  private loggedOnUser: BehaviorSubject<User> = new BehaviorSubject(null);
  loggedOnUser$: Observable<User> = this.loggedOnUser.asObservable();

  constructor(private http: HttpClient) { }

  /**
   * @remarks
   * Registers a User on the app 
   * 
   * @returns 
   * the registered User
   */
  register(registerUser: RegisterUser) {
    this.http.post<User>(`${this.baseUrl}/Register`, registerUser).subscribe(user => {
      this.setLoggedOnUser(user);
    });
  }

  /**
   * @remarks
   * Sets the logged on User
   */
  setLoggedOnUser(user: User) {
    this.loggedOnUser.next(user);
  }
}
