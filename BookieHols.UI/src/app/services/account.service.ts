import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { SnackbarAction, SnackbarClassType, SnackbarDuration } from '../Models/snackbar-item';
import { User } from '../Models/user';
import { MessageHandlingService } from './message-handling.service';

export interface RegisterUser {
  username: string;
  password: string;
  email: string;
}

export interface LoginUser {
  username: string;
  password: string;
}

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl: string = "https://localhost:7161/api/Account"
  private loggedOnUser: BehaviorSubject<User> = new BehaviorSubject(null);
  loggedOnUser$: Observable<User> = this.loggedOnUser.asObservable();

  constructor(
    private http: HttpClient, 
    private messageHandlingService: MessageHandlingService,
    private router: Router) 
    { }

  /**
   * @remarks
   * Registers a User on the app 
   * 
   * @returns 
   * the registered User
   */
  register(registerUser: RegisterUser) {
    this.http.post<User>(`${this.baseUrl}/Register`, registerUser).subscribe(user => {
      if(user) {
        this.setLoggedOnUser(user);
        this.router.navigate(['/home']);
      }
    }, error => {
      this.messageHandlingService.displayMessage({message: 'Unable to submit. There are errors on the form', action: SnackbarAction.Close, classType: SnackbarClassType.Error, duration: SnackbarDuration.Medium});
    });
  }

  /**
   * @remarks
   * Checks whether a username has already been used and is therefore, not unique
   *  
   * @param username 
   * The username string value the user has entered
   * 
   * @returns 
   * An Observable which wraps a boolean
   */
  checkUsernameUnique(username: string): Observable<boolean> {
    return this.http.get<boolean>(`${this.baseUrl}/CheckUsername?username=${username}`);
  }


  /**
   * @remarks
   * Checks whether an account with the email address already exists
   * 
   * @param email
   * The email string to check
   * 
   * @returns
   * An Observable which wraps a boolean indicating whether an account with the email address already exists
   */
  checkEmailUnique(email: string): Observable<boolean> {
    return this.http.get<boolean>(`${this.baseUrl}/CheckEmail?email=${email}`);
  }


  /**
   * @remarks
   * logs a User in
   * 
   * @returns 
   * the logged in User
   */
  login(loginUser: LoginUser) {
    this.http.post<User>(`${this.baseUrl}/Login`, loginUser).subscribe(user => {
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
